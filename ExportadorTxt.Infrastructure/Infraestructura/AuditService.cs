using Dapper;
using ExportadorTxt.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class AuditService : IAuditService
{
    private readonly string? _connectionString;

    public AuditService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task RegistrarArchivoAsync(AuditRecord registro)
    {
        using var connection = new SqlConnection(_connectionString);

        var parametros = new DynamicParameters();
        parametros.Add("@NombreArchivo", registro.NombreArchivo);
        parametros.Add("@TipoReporte", registro.TipoReporte);
        parametros.Add("@RutaCompleta", registro.RutaCompleta);
        parametros.Add("@AnioMes", registro.AnioMes);
        parametros.Add("@TotalRegistros", registro.TotalRegistros);
        parametros.Add("@TotalPaginas", registro.TotalPaginas);
        parametros.Add("@TamanoArchivoBytes", registro.TamanoArchivoBytes);
        parametros.Add("@FechaInicio", registro.FechaInicio);
        parametros.Add("@FechaFin", registro.FechaFin);
        parametros.Add("@IdGenerado", dbType: DbType.Int64,direction: ParameterDirection.Output);

        await connection.ExecuteAsync(
            "SPR_REGISTRAR_AUDITORIA",
            parametros,
            commandType: CommandType.StoredProcedure,
            commandTimeout: 60);

        var idGenerado = parametros.Get<long>("@IdGenerado");
    }

    public async Task RegistrarErrorAsync(ErrorRecord error)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync(
                "SPR_REGISTRAR_ERROR",
                new
                {
                    TipoReporte = error.TipoReporte,
                    AnioMes = error.AnioMes,
                    NombreArchivo = error.NombreArchivo,
                    MensajeError = error.MensajeError,
                    StackTrace = error.StackTrace,
                    TipoExcepcion = error.TipoExcepcion,
                    PaginaFallo = error.PaginaFallo
                },
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[AUDIT-CRITICO] No se pudo registrar el error en BD: {ex.Message}");
        }
    }
}
