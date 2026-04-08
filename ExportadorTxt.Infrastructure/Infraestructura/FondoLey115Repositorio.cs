using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class FondoLey115Repositorio : IRepositorio<FondoLey115>
{
    private readonly string? _connectionString;

    public FondoLey115Repositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<FondoLey115>> ObtenerDatosAsync(int anioMes)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<FondoLey115>(
            "SPR_OBTENER_FONDO_LEY_115",
            new { ANIOMES = anioMes },
            commandType: CommandType.StoredProcedure);
    }
}