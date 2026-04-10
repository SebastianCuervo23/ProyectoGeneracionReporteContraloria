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

    public FondoLey115Handler(IRepositorio<FondoLey115> repositorio, IArchivoService<FondoLey115> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLey115Command request, CancellationToken cancellationToken)
    {
        await _archivoService.InicializarArchivoAsync();

        int pageNumber = 1;

        while (true)
        {
            var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);
            if (!lote.Any()) break;

            await _archivoService.AgregarLoteAsync(lote);

            Console.WriteLine($"[{typeof(FondoLey115).Name}] Página {pageNumber} procesada ({lote.Count()} registros)");

            if (lote.Count() < PageSize) break; // última página

            pageNumber++;
        }
    }
}