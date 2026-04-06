using ExportadorTxt.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class ArchivoService<T> : IArchivoService<T>
{
    private readonly string? _rutaSalida;
    private readonly string _nombreArchivo;

    public ArchivoService(IConfiguration configuration)
    {
        _rutaSalida = configuration["RutaSalida"];
        _nombreArchivo = typeof(T).Name;
    }

    public async Task GenerarArchivoAsync(IEnumerable<T> datos)
    {
        var nombre = $"{_nombreArchivo}_{DateTime.Now:yyyyMMddHHmm}.txt";
        var rutaCompleta = Path.Combine(_rutaSalida!, nombre);

        var propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var lineas = datos.Select(item =>
            string.Join("|", propiedades.Select(p =>
            {
                var valor = p.GetValue(item);
                return valor is DateTime dt ? dt.ToString("yyyy-MM-dd") :
                       valor?.ToString() ?? string.Empty;
            })));

        await File.WriteAllLinesAsync(rutaCompleta, lineas, Encoding.UTF8);
    }
}