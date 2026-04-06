using ExportadorTxt.Domain.Entidades;

namespace ExportadorTxt.Application.Interfaces;
/*public interface ISubsidioEspecieRepositorio
{
    Task<IEnumerable<SubsidioEspecie>> ObtenerDatosAsync(int anioMes);
}*/

public interface IRepositorio<T>
{
    Task<IEnumerable<T>> ObtenerDatosAsync(int anioMes);
}