using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class CuotaMonetariaHandler : IRequestHandler<GenerarCuotaMonetariaCommand>
{
    private readonly IRepositorio<CuotaMonetaria> _repositorio;
    private readonly IArchivoService<CuotaMonetaria> _archivoService;

    public CuotaMonetariaHandler(IRepositorio<CuotaMonetaria> repositorio, IArchivoService<CuotaMonetaria> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarCuotaMonetariaCommand request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}