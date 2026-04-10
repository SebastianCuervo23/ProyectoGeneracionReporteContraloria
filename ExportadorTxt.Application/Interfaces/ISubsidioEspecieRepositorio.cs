using ExportadorTxt.Domain.Entidades;

namespace ExportadorTxt.Application.Interfaces;

public interface IRepositorio<T>
{
    Task<IEnumerable<T>> ObtenerDatosAsync(int anioMes, int pageNumber, int pageSize);
}