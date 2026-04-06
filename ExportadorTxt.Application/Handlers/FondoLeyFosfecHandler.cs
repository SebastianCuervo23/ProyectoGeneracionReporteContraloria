using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLeyFosfecHandler : IRequestHandler<GenerarFondoLeyFosfecCommand>
{
    private readonly IRepositorio<FondoLeyFosfec> _repositorio;
    private readonly IArchivoService<FondoLeyFosfec> _archivoService;

    public FondoLeyFosfecHandler(IRepositorio<FondoLeyFosfec> repositorio, IArchivoService<FondoLeyFosfec> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLeyFosfecCommand request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}