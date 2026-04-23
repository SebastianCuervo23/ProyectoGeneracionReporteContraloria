using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura.Repositorios;

public class ContratosRepositorio : IRepositorio<Contratos>
{
    private readonly string? _connectionString;

    public ContratosRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<Contratos>> ObtenerDatosAsync(int anioMes, int pageNumber, int pageSize)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Contratos>(
            "SPR_OBTENER_CONTRATOS",
            new { ANIOMES = anioMes, PageNumber = pageNumber, PageSize = pageSize },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300);
    }
}