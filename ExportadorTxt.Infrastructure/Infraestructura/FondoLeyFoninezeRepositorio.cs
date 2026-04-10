using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class FondoLeyFoninezeRepositorio : IRepositorio<FondoLeyFoniñez>
{
    private readonly string? _connectionString;

    public FondoLeyFoninezeRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<FondoLeyFoniñez>> ObtenerDatosAsync(int anioMes, int pageNumber, int pageSize)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<FondoLeyFoniñez>(
            "SPR_OBTENER_FONDO_LEY_FONINEZ",
            new { ANIOMES = anioMes, PageNumber = pageNumber, PageSize = pageSize },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300);
    }
}