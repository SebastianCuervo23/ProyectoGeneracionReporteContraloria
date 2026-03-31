using ExportadorTxt.Domain.Entidades;
using Microsoft.Extensions.Configuration;
using ExportadorTxt.Application.Interfaces;
using System.Text;


namespace ExportadorTxt.Infrastructure.Infraestructura
{
    public class ArchivoService : IArchivoService
    {
        private readonly string? _ruta;

        public ArchivoService(IConfiguration configuration)
        {
            _ruta = configuration["RutaSalida"];
        }

        public async Task GenerarArchivoAsync(IEnumerable<SubsidioEspecie> datos)
        {
            var nombre = $"Subsidio_Especie_Microdato_{DateTime.Now:yyyyMMddhhmm}.txt";
            var rutaCompleta = Path.Combine(_ruta, nombre);

            var lineas = datos.Select(d =>
                $"{d.IdCCF}|{d.TipoIdentificacionAfiliado}|{d.NumeroIdentificacionAfiliado}|{d.Categoria}|{d.TipoIdentificacionPersonaCargo}|{d.NumeroIdentificacionPersonaCargo}|{d.TipoSubsidio}|{d.ValorSubsidio}"
            );
            await File.WriteAllLinesAsync(rutaCompleta, lineas, Encoding.UTF8);
        }
    }
}
