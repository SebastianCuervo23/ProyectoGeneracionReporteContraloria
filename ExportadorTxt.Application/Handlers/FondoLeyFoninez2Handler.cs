using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLeyFoninez2Handler : IRequestHandler<GenerarFondoLeyFoninez2Command>
{
    private readonly IRepositorio<FondoLeyFoniñez2> _repositorio;
    private readonly IArchivoService<FondoLeyFoniñez2> _archivoService;
    private const int PageSize = 100000;

    public FondoLeyFoninez2Handler(IRepositorio<FondoLeyFoniñez2> repositorio, IArchivoService<FondoLeyFoniñez2> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLeyFoninez2Command request, CancellationToken cancellationToken)
    {
        await _archivoService.InicializarArchivoAsync();

        int pageNumber = 1;

        while (true)
        {
            var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);
            if (!lote.Any()) break;

            await _archivoService.AgregarLoteAsync(lote);

            Console.WriteLine($"[{typeof(FondoLeyFoniñez2).Name}] Página {pageNumber} procesada ({lote.Count()} registros)");

            if (lote.Count() < PageSize) break;

            pageNumber++;
        }
    }
}