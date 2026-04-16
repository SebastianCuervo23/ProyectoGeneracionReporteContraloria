using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLey115Handler : IRequestHandler<GenerarFondoLey115Command>
{
    private readonly IRepositorio<FondoLey115> _repositorio;
    private readonly IArchivoService<FondoLey115> _archivoService;
    private const int PageSize = 100000;
    private readonly IAuditService _auditService;

    public FondoLey115Handler(
        IRepositorio<FondoLey115> repositorio, 
        IArchivoService<FondoLey115> archivoService, 
        IAuditService auditService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
        _auditService = auditService;
    }

    public async Task Handle(GenerarFondoLey115Command request, CancellationToken cancellationToken)
    {
        var tipoReporte = typeof(FondoLey115).Name;
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

                Console.WriteLine($"[{typeof(FondoLey115).Name}] Página {pageNumber} procesada ({lote.Count()} registros)");

                if (lote.Count() < PageSize) break;

                pageNumber++;
            }
            var rutaCompleta = _archivoService.ObtenerRutaCompleta();
            var tamano = File.Exists(rutaCompleta) ? new FileInfo(rutaCompleta).Length : 0L;

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