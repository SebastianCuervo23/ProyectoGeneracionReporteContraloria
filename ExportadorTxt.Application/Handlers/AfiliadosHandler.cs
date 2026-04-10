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
        private const int PageSize = 100000;

        public AfiliadosHandler(IRepositorio<Afiliados> repositorio, IArchivoService<Afiliados> archivoService)
        {
            _repositorio = repositorio;
            _archivoService = archivoService;
        }
        public async Task Handle(GenerarAfiliadosCommand request, CancellationToken cancellationToken)
        {
            await _archivoService.InicializarArchivoAsync();

            int pageNumber = 1;

            while (true)
            {
                var lote = await _repositorio.ObtenerDatosAsync(request.AnioMes, pageNumber, PageSize);
                if (!lote.Any()) break;

                await _archivoService.AgregarLoteAsync(lote);

                Console.WriteLine($"[{typeof(Afiliados).Name}] Página {pageNumber} procesada ({lote.Count()} registros)");

                if (lote.Count() < PageSize) break; // última página

                pageNumber++;
            }
        }
    }
}
