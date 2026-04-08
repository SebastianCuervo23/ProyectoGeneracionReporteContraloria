using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class ContratosRepositorio : IRepositorio<Contratos>
{
    private readonly string? _connectionString;

    public ContratosRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Contratos>> ObtenerDatosAsync(int anioMes)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Contratos>(
            "SPR_OBTENER_CONTRATOS",
            new { ANIOMES = anioMes },
            commandType: CommandType.StoredProcedure);
    }
}