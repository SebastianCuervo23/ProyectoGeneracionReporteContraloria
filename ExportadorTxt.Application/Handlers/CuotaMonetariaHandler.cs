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

    public CuotaMonetariaHandler(IRepositorio<CuotaMonetaria> repositorio, IArchivoService<CuotaMonetaria> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarCuotaMonetariaCommand request, CancellationToken cancellationToken)
    {
        await _archivoService.InicializarArchivoAsync();

        int pageNumber = 1;

        while (true)
        {
            var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);
            if (!lote.Any()) break;

            await _archivoService.AgregarLoteAsync(lote);

            Console.WriteLine($"[{typeof(CuotaMonetaria).Name}] Página {pageNumber} procesada ({lote.Count()} registros)");

            if (lote.Count() < PageSize) break; // última página

            pageNumber++;
        }
    }
}