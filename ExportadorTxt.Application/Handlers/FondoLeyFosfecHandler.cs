using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLeyFosfecHandler : IRequestHandler<GenerarFondoLeyFosfecCommand>
{
    private readonly IRepositorio<FondoLeyFosfec> _repositorio;
    private readonly IArchivoService<FondoLeyFosfec> _archivoService;
    private const int PageSize = 100000;

    public FondoLeyFosfecHandler(IRepositorio<FondoLeyFosfec> repositorio, IArchivoService<FondoLeyFosfec> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLeyFosfecCommand request, CancellationToken cancellationToken)
    {
        await _archivoService.InicializarArchivoAsync();

        int pageNumber = 1;

        while (true)
        {
            var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);
            if (!lote.Any()) break;

            await _archivoService.AgregarLoteAsync(lote);

            Console.WriteLine($"[{typeof(FondoLeyFosfec).Name}] Página {pageNumber} procesada ({lote.Count()} registros)");

            if (lote.Count() < PageSize) break; 

            pageNumber++;
        }
    }
}