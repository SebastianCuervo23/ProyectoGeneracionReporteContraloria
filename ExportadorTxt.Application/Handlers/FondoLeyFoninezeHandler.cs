using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class FondoLeyFoninezeHandler : IRequestHandler<GenerarFondoLeyFoninezeCommand>
{
    private readonly IRepositorio<FondoLeyFoniñez> _repositorio;
    private readonly IArchivoService<FondoLeyFoniñez> _archivoService;

    public FondoLeyFoninezeHandler(IRepositorio<FondoLeyFoniñez> repositorio, IArchivoService<FondoLeyFoniñez> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarFondoLeyFoninezeCommand request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}