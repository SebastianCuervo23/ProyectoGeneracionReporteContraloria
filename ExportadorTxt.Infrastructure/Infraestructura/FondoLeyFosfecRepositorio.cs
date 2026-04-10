using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class FondoLeyFosfecRepositorio : IRepositorio<FondoLeyFosfec>
{
    private readonly string? _connectionString;

    public FondoLeyFosfecRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<FondoLeyFosfec>> ObtenerDatosAsync(int anioMes,int pageNumber,int pageSize )
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<FondoLeyFosfec>(
            "SPR_OBTENER_FONDO_LEY_FOSFEC",
            new { ANIOMES = anioMes, PageNumber = pageNumber, PageSize = pageSize },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300);
    }
}