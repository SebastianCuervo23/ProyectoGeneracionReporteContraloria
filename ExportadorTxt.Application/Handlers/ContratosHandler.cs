using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class ContratosHandler : IRequestHandler<GenerarContratosCommand>
{
    private readonly IRepositorio<Contratos> _repositorio;
    private readonly IArchivoService<Contratos> _archivoService;

    public ContratosHandler(IRepositorio<Contratos> repositorio, IArchivoService<Contratos> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarContratosCommand request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}