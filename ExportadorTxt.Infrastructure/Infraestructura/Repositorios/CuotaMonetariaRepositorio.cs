using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura.Repositorios;

public class CuotaMonetariaRepositorio : IRepositorio<CuotaMonetaria>
{
    private readonly string? _connectionString;

    public CuotaMonetariaRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<CuotaMonetaria>> ObtenerDatosAsync(int anioMes, int pageNumber, int pageSize)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<CuotaMonetaria>(
            "SPR_OBTENER_CUOTA_MONETARIA",
            new { ANIOMES = anioMes, PageNumber = pageNumber, PageSize = pageSize },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300);
    }
}