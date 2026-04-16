using ExportadorTxt.Aplication.Interfaces;
using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;
using Microsoft.Extensions.Options;

namespace ExportadorTxt.Application.Handlers;

public class ContratosHandler : IRequestHandler<GenerarContratosCommand>
{
    private readonly IRepositorio<Contratos> _repositorio;
    private readonly IArchivoService<Contratos> _archivoService;
    private const int PageSize = 100000;
    private readonly IAuditService _auditService;
    private readonly IEmailService _emailService;
    private readonly EmailSettings _emailSettings;

    public ContratosHandler(
        IRepositorio<Contratos> repositorio,
        IArchivoService<Contratos> archivoService,
        IAuditService auditService, 
        IEmailService emailService, 
        IOptions<EmailSettings> options)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
        _auditService = auditService;
        _emailService = emailService;
        _emailSettings = options.Value;
    }

    public async Task Handle(GenerarContratosCommand request, CancellationToken cancellationToken)
    {
        var tipoReporte = typeof(Contratos).Name;
        var fechaInicio = DateTime.Now;
        long totalRegistros=0;
        int totalPaginas = 0;

        try
        {

            await _archivoService.InicializarArchivoAsync();

            int pageNumber = 1;

            while (true)
            {
                var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);
                if (!lote.Any()) break;

                await _archivoService.AgregarLoteAsync(lote);

                var countLote=lote.Count();
                totalRegistros +=countLote;
                totalPaginas =pageNumber;

                Console.WriteLine($"[{tipoReporte}] Página {pageNumber} procesada ({countLote} registros)");

                if (lote.Count() < PageSize) break;

                pageNumber++;
            }
            var rutaCompleta = _archivoService.ObtenerRutaCompleta();
            var tamano = File.Exists(rutaCompleta)? new FileInfo(rutaCompleta).Length : 0L;

            await _auditService.RegistrarArchivoAsync(new AuditRecord(
                NombreArchivo: Path.GetFileName(rutaCompleta),
                TipoReporte: tipoReporte,
                RutaCompleta: rutaCompleta,
                AnioMes: request.AnioMes,
                TotalRegistros: totalRegistros,
                TotalPaginas: totalPaginas,
                TamanoArchivoBytes: tamano,
                FechaInicio: fechaInicio,
                FechaFin: DateTime.Now
                ));


            await _emailService.EnviarEmail(_emailSettings.EmailReceptor,
    $"Reporte {tipoReporte} generado — periodo {request.AnioMes}",
    $"El reporte {tipoReporte} para el periodo {request.AnioMes} fue generado exitosamente.\n" +
    $"Registros: {totalRegistros} | Páginas: {totalPaginas} | Tamaño: {tamano / 1024} KB \n" +
    $"    ");

        }

        catch (Exception ex) {
            await _auditService.RegistrarErrorAsync(new ErrorRecord(
                        TipoReporte: tipoReporte,
                        AnioMes: request.AnioMes,
                        NombreArchivo: null,
                        MensajeError: ex.Message,
                        StackTrace: ex.StackTrace,
                        TipoExcepcion: ex.GetType().FullName,
                        PaginaFallo: null
                    ));

            Console.WriteLine($"[{tipoReporte}] ERROR: {ex.Message}");
            throw;
        }
    }
}