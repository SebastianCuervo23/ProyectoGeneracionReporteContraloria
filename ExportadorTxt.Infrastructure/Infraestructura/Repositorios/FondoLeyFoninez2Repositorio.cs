using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura.Repositorios;

public class FondoLeyFoninez2Repositorio : IRepositorio<FondoLeyFoniñez2>
{
    private readonly string? _connectionString;

    public FondoLeyFoninez2Repositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<FondoLeyFoniñez2>> ObtenerDatosAsync(int anioMes, int pageNumber, int pageSize)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<FondoLeyFoniñez2>(
            "SPR_OBTENER_FONDO_LEY_FONINEZ2",
            new { ANIOMES = anioMes, PageNumber = pageNumber, PageSize = pageSize },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300);
    }
}