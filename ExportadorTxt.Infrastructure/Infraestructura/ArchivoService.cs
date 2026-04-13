using ExportadorTxt.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class ArchivoService<T> : IArchivoService<T>
{
    private readonly string? _rutaSalida;
    private readonly string _nombreArchivo;
    private string? _rutaCompleta;
    private readonly PropertyInfo[] _propiedades;


    public ArchivoService(IConfiguration configuration)
    {
        _rutaSalida = configuration["RutaSalida"];
        _nombreArchivo = typeof(T).Name;
        _propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

    }
    public string? ObtenerRutaCompleta()
    {
        return _rutaCompleta;
    }

    public Task InicializarArchivoAsync()
    {
        
        var nombre = $"{_nombreArchivo}_{DateTime.Now:yyyyMMddHHmm}.txt";
        _rutaCompleta = Path.Combine(_rutaSalida!, nombre);

        // Crea el archivo vacío (o lo sobreescribe si existe)
        File.WriteAllText(_rutaCompleta, string.Empty, Encoding.UTF8);
        return Task.CompletedTask;
    }

    public async Task AgregarLoteAsync(IEnumerable<T> datos)
    {
        if (_rutaCompleta is null)
            throw new InvalidOperationException("Debes llamar InicializarArchivoAsync antes de AgregarLoteAsync.");

        var lineas = datos.Select(item =>
            string.Join("|", _propiedades.Select(p =>
            {
                var valor = p.GetValue(item);
                return valor is DateTime dt
                    ? dt.ToString("yyyy-MM-dd")
                    : valor?.ToString() ?? string.Empty;
            })));

        await File.AppendAllLinesAsync(_rutaCompleta, lineas, Encoding.UTF8);
    }
}