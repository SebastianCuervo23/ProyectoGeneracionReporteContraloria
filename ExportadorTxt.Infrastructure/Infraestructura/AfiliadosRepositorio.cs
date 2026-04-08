using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class AfiliadosRepositorio : IRepositorio<Afiliados>
{
    private readonly string? _connectionString;

    public AfiliadosRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Afiliados>> ObtenerDatosAsync(int anioMes)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Afiliados>(
            "SPR_OBTENER_AFILIADOS",
            new { ANIOMES = anioMes },
            commandType: CommandType.StoredProcedure);
    }
}