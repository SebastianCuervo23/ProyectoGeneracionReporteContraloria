using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLey115Handler : IRequestHandler<GenerarFondoLey115Command>
{
    private readonly IRepositorio<FondoLey115> _repositorio;
    private readonly IArchivoService<FondoLey115> _archivoService;

    public FondoLey115Handler(IRepositorio<FondoLey115> repositorio, IArchivoService<FondoLey115> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLey115Command request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}