/*using ExportadorTxt.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportadorTxt.Application.UseCases
{
    public class GenerarArchivoSubsidioUseCase
    {
        private readonly ISubsidioEspecieRepositorio _repositorio;
        private readonly IArchivoService _archivoService;

        public GenerarArchivoSubsidioUseCase(ISubsidioEspecieRepositorio repositorio,IArchivoService archivoService)
        {
            _repositorio = repositorio;
            _archivoService = archivoService;
        }
        public async Task EjecutarAsync(int anioMes)
        {
            var datos = await _repositorio.ObtenerDatosAsync(anioMes);

            if (!datos.Any())
                return;
            await _archivoService.GenerarArchivoAsync(datos);
        }
    }
}*/
