using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLeyFovisHandler : IRequestHandler<GenerarFondoLeyFovisCommand>
{
    private readonly IRepositorio<FondoLeyFovis> _repositorio;
    private readonly IArchivoService<FondoLeyFovis> _archivoService;

    public FondoLeyFovisHandler(IRepositorio<FondoLeyFovis> repositorio, IArchivoService<FondoLeyFovis> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLeyFovisCommand request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}