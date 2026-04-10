using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class SubsidioEspecieHandler : IRequestHandler<GenerarSubsidioEspecieCommand>
{
    private readonly IRepositorio<SubsidioEspecie> _repositorio;
    private readonly IArchivoService<SubsidioEspecie> _archivoService;
    private const int PageSize = 100000;

    public SubsidioEspecieHandler(
        IRepositorio<SubsidioEspecie> repositorio,
        IArchivoService<SubsidioEspecie> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarSubsidioEspecieCommand request, CancellationToken cancellationToken)
    {
        await _archivoService.InicializarArchivoAsync();

        int pageNumber = 1;

        while (true)
        {
            var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);

            if (!lote.Any()) break;

            await _archivoService.AgregarLoteAsync(lote);

            Console.WriteLine($"[{typeof(SubsidioEspecie).Name}] Página {pageNumber} procesada ({lote.Count()} registros)");

            if (lote.Count() < PageSize) break; // última página

            pageNumber++;
        }
    }
}