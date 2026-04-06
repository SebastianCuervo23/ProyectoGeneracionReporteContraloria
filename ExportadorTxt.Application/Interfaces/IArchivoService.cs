using ExportadorTxt.Domain.Entidades;

namespace ExportadorTxt.Application.Interfaces;
/*public interface IArchivoService
{
    Task GenerarArchivoAsync(IEnumerable<SubsidioEspecie> datos);
}*/
public interface IArchivoService<T>
{
    Task GenerarArchivoAsync(IEnumerable<T> datos);
}