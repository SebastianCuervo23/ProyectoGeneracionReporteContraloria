using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLeyFoninez2Handler : IRequestHandler<GenerarFondoLeyFoninez2Command>
{
    private readonly IRepositorio<FondoLeyFoniñez2> _repositorio;
    private readonly IArchivoService<FondoLeyFoniñez2> _archivoService;

    public FondoLeyFoninez2Handler(IRepositorio<FondoLeyFoniñez2> repositorio, IArchivoService<FondoLeyFoniñez2> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLeyFoninez2Command request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}