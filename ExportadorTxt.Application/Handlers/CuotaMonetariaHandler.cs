using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class CuotaMonetariaHandler : IRequestHandler<GenerarCuotaMonetariaCommand>
{
    private readonly IRepositorio<CuotaMonetaria> _repositorio;
    private readonly IArchivoService<CuotaMonetaria> _archivoService;
    private const int PageSize = 100000;
    private readonly IAuditService _auditService;
    private readonly ResultadoArchivos _resultadoArchivos;

    public CuotaMonetariaHandler(
        IRepositorio<CuotaMonetaria> repositorio, 
        IArchivoService<CuotaMonetaria> archivoService, 
        IAuditService auditService,
        ResultadoArchivos resultadoArchivos)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
        _auditService = auditService;
        _resultadoArchivos = resultadoArchivos;
    }

    public async Task Handle(
        GenerarCuotaMonetariaCommand request, 
        CancellationToken cancellationToken
        )
    {
        var tipoReporte = typeof(CuotaMonetaria).Name;
        var fechaInicio = DateTime.Now;
        long totalRegistros = 0;
        int totalPaginas = 0;

        try
        {
            bool archivoInicializado = false;
            int pageNumber = 1;

            while (true)
            {
                var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);

                if (!lote.Any())
                    break;

                if (!archivoInicializado)
                {
                    await _archivoService.InicializarArchivoAsync();
                    archivoInicializado = true;
                }

                await _archivoService.AgregarLoteAsync(lote);

                var countLote = lote.Count();
                totalRegistros += countLote;
                totalPaginas = pageNumber;

                Console.WriteLine($"[{typeof(CuotaMonetaria).Name}] Página {pageNumber} procesada ({countLote} registros)");

                if (countLote < PageSize)
                    break;

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
            var tamanoArchivoGB = (double)tamano / 1073741824;
            if (totalRegistros > 0)
            {
                _resultadoArchivos.Agregar("Cuota Monetaria", totalRegistros.ToString(), tamanoArchivoGB.ToString("F3"));
            }
        }

        catch (Exception ex)
        {
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