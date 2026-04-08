using ExportadorTxt.Application.Commands;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using MediatR;


namespace ExportadorTxt.Application.Handlers
{
    public class AfiliadosHandler : IRequestHandler<GenerarAfiliadosCommand>
    {
        private readonly IRepositorio<Afiliados> _repositorio;
        private readonly IArchivoService<Afiliados> _archivoService;

        public AfiliadosHandler(IRepositorio<Afiliados> repositorio, IArchivoService<Afiliados> archivoService)
        {
            _repositorio = repositorio;
            _archivoService = archivoService;
        }
        public async Task Handle(GenerarAfiliadosCommand request, CancellationToken cancellationToken)
        {
            var datos = await _repositorio.ObtenerDatosAsync(request.AnioMes);
            if (!datos.Any()) return;
            await _archivoService.GenerarArchivoAsync(datos);
        }
    }
}
