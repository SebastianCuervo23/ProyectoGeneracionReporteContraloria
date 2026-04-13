namespace ExportadorTxt.Application.Interfaces;
public interface IArchivoService<T>
{
    Task InicializarArchivoAsync();
    Task AgregarLoteAsync(IEnumerable<T> datos);
    string? ObtenerRutaCompleta();
}