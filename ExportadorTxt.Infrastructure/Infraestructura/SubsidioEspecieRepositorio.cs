using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Extensions.Configuration;
namespace ExportadorTxt.Application.Interfaces;

public class SubsidioEspecieRepositorio : ISubsidioEspecieRepositorio
{
    private readonly string? ConnectionString;

    public SubsidioEspecieRepositorio(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<IEnumerable<SubsidioEspecie>> ObtenerDatosAsync(int anioMes)
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            var subsidiosEspecie = await connection.QueryAsync<SubsidioEspecie>("SPR_OBTENER_SUBSIDIO_ESPECIE_TEST",
                    new { ANIO_MES = anioMes },
                commandType: CommandType.StoredProcedure);
            return subsidiosEspecie;
        }
    }
}
