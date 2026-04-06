using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;

namespace ExportadorTxt.Application.Handlers;

public class SubsidioEspecieHandler : IRequestHandler<GenerarSubsidioEspecieCommand>
{
    private readonly IRepositorio<SubsidioEspecie> _repositorio;
    private readonly IArchivoService<SubsidioEspecie> _archivoService;

    public SubsidioEspecieHandler(IRepositorio<SubsidioEspecie> repositorio, IArchivoService<SubsidioEspecie> archivoService)
    {
        _repositorio = repositorio;
        _archivoService = archivoService;
    }

    public async Task Handle(GenerarSubsidioEspecieCommand request, CancellationToken cancellationToken)
    {
        var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
        if (!datos.Any()) return;
        await _archivoService.GenerarArchivoAsync(datos);
    }
}