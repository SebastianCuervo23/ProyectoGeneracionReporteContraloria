using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class FondoLeyFovisRepositorio : IRepositorio<FondoLeyFovis>
{
    private readonly string? _connectionString;

    public FondoLeyFovisRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<FondoLeyFovis>> ObtenerDatosAsync(int anioMes, int pageNumber, int pageSize)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<FondoLeyFovis>(
            "SPR_OBTENER_FONDO_LEY_FOVIS",
            new { ANIOMES = anioMes, PageNumber = pageNumber, PageSize = pageSize },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300);
    }
}