using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLeyFoninezeHandler : IRequestHandler<GenerarFondoLeyFoninezeCommand>
{
    private readonly IRepositorio<FondoLeyFoniñez> _repositorio;
    private readonly IArchivoService<FondoLeyFoniñez> _archivoService;
    private const int PageSize = 100000;
    private readonly IAuditService _auditService;

    public FondoLeyFoninezeHandler(IRepositorio<FondoLeyFoniñez> repositorio, IArchivoService<FondoLeyFoniñez> archivoService, IAuditService auditService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
        _auditService = auditService;
    }

    public async Task Handle(GenerarFondoLeyFoninezeCommand request, CancellationToken cancellationToken)
    {
        var tipoReporte = typeof(Afiliados).Name;
        var fechaInicio = DateTime.Now;
        long totalRegistros = 0;
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
                var countLote = lote.Count();
                totalRegistros += countLote;
                totalPaginas = pageNumber;
                Console.WriteLine($"[{tipoReporte}] Página {pageNumber} procesada ({countLote} registros)");

                if (lote.Count() < PageSize) break;

                pageNumber++;
            }
            var rutaCompleta = _archivoService.ObtenerRutaCompleta();  // ver nota (1)
            var tamano = File.Exists(rutaCompleta)
                               ? new FileInfo(rutaCompleta).Length
                               : 0L;

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