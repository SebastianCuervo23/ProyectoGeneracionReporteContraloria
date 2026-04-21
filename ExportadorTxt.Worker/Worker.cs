/*using ExportadorTxt.Application.Commands;
using MediatR;

namespace ExportadorTxt.Worker;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _config;

    public Worker(IServiceProvider serviceProvider, IConfiguration config)
    {
        _serviceProvider = serviceProvider;
        _config = config;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var horaEjecucion = _config.GetValue<int>("HoraEjecucion");
        var diaEjecucion = _config.GetValue<int>("DiaEjecucion");

        DateTime? ultimaEjecucion = null;

        while (!stoppingToken.IsCancellationRequested)
        {
            var ahora = DateTime.Now;

            var esDiaCorrecto = ahora.Day == diaEjecucion;

            var esHoraCorrecta =ahora.Hour == horaEjecucion;

            var Ejecucion = ultimaEjecucion?.Hour == ahora.Hour;

            if (esDiaCorrecto && esHoraCorrecta && !Ejecucion)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();

                    var proceso = scope.ServiceProvider.GetRequiredService<ProcesoGeneralService>();

                    await proceso.Ejecutar(stoppingToken);

                    ultimaEjecucion = ahora;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
                  
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
*/

namespace ExportadorTxt.Worker; 
public class Worker : BackgroundService { 

    private readonly IServiceProvider _serviceProvider; 
    private readonly IConfiguration _config; 

 public Worker(
     IServiceProvider serviceProvider, 
     IConfiguration config) 
    { 
        _serviceProvider = serviceProvider; 
        _config = config; } 
    
protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
    { 
        var intervalo = _config.GetValue<int>("IntervaloMinutos"); 
        while (!stoppingToken.IsCancellationRequested) 
        { 
            try { 
                using var scope = _serviceProvider.CreateScope(); 
                var proceso = scope.ServiceProvider.GetRequiredService<ProcesoGeneralService>();
                await proceso.Ejecutar(stoppingToken); 
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine($"Error en ejecución: {ex.Message}"); 
            } 
            await Task.Delay(TimeSpan.FromMinutes(intervalo), stoppingToken);
        } 
    } 
}