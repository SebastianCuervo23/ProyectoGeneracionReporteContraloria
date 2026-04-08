/*using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Extensions.Configuration;
namespace ExportadorTxt.Application.Interfaces;

public class SubsidioEspecieRepositorio : IRepositorio<SubsidioEspecie>
{
    private readonly string? ConnectionString;

    public SubsidioEspecieRepositorio(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }

    //SUBSISIO EN ESPECIE
    public async Task<IEnumerable<SubsidioEspecie>> ObtenerDatosAsync(int anioMes)
    {
        using (var connection = new SqlConnection(ConnectionString))
        {
            var subsidiosEspecie = await connection.QueryAsync<SubsidioEspecie>("SPR_OBTENER_SUBSIDIO_ESPECIE",
                    new { ANIO_MES = anioMes },
                commandType: CommandType.StoredProcedure);
            return subsidiosEspecie;
        }
    }
     //FONDOS DE LEY FOVIS
     public async Task<IEnumerable<FondoLeyFovis>> ObtenerFondosLeyFovisAsync(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var fondosLeyFovis = await connection.QueryAsync<FondoLeyFovis>("SPR_OBTENER_FONDOS_LEY_FOVIS_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return fondosLeyFovis;
         }
     }
     //AFILIADOS
     public async Task<IEnumerable<Afiliados>> ObtenerAfiliadosAsync(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var afiliados = await connection.QueryAsync<Afiliados>("SPR_OBTENER_AFILIADOS_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return afiliados;
         }
     }
     //FONDOS DE LEY FOSFEC
     public async Task<IEnumerable<FondoLeyFosfec>> ObtenerFondosLeyFosfecAsync(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var fondosLeyFosfec = await connection.QueryAsync<FondoLeyFosfec>("SPR_OBTENER_FONDOS_LEY_FOSFEC_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return fondosLeyFosfec;
         }
     }
     //FONDOS DE LEY FONIÑEZ
     public async Task<IEnumerable<FondoLeyFoniñez>> ObtenerFondosLeyFoniñezAsync(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var fondosLeyFoniñez = await connection.QueryAsync<FondoLeyFoniñez>("SPR_OBTENER_FONDOS_LEY_FONIÑEZ_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return fondosLeyFoniñez;
         }
     }

     //FONDOS DE LEY FONIÑEZ 2
     public async Task<IEnumerable<FondoLeyFoniñez2>> ObtenerFondosLeyFoniñez2Async(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var fondosLeyFoniñez2 = await connection.QueryAsync<FondoLeyFoniñez2>("SPR_OBTENER_FONDOS_LEY_FONIÑEZ_2_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return fondosLeyFoniñez2;
         }
     }

     //CONTRATOS
     public async Task<IEnumerable<Contratos>> ObtenerContratosAsync(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var contratos = await connection.QueryAsync<Contratos>("SPR_OBTENER_CONTRATOS_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return contratos;
         }
     }

     //CUOTA MONETARIA
     public async Task<IEnumerable<CuotaMonetaria>> ObtenerCuotaMonetariaAsync(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var cuotaMonetaria = await connection.QueryAsync<CuotaMonetaria>("SPR_OBTENER_CUOTA_MONETARIA_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return cuotaMonetaria;
         }
     }

     //FONDOS DE LEY 115
     public async Task<IEnumerable<FondoLey115>> ObtenerFondosLey115Async(int anioMes)
     {
         using (var connection = new SqlConnection(ConnectionString))
         {
             var fondosLey115 = await connection.QueryAsync<FondoLey115>("SPR_OBTENER_FONDOS_LEY_115_TEST",
                     new { ANIO_MES = anioMes },
                 commandType: CommandType.StoredProcedure);
             return fondosLey115;
         }


     }
}
*/
using Dapper;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class SubsidioEspecieRepositorio : IRepositorio<SubsidioEspecie>
{
    private readonly string? _connectionString;

    public SubsidioEspecieRepositorio(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<SubsidioEspecie>> ObtenerDatosAsync(int anioMes)
    {
        using var connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<SubsidioEspecie>(
            "SPR_OBTENER_SUBSIDIO_ESPECIE_TEST",
            new { ANIOMES = anioMes },
            commandType: CommandType.StoredProcedure);
    }
}