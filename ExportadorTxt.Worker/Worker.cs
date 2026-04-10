using ExportadorTxt.Application.Commands;
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
        var intervalo = _config.GetValue<int>("IntervaloMinutos");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                Console.WriteLine($"[{DateTime.Now}] Iniciando proceso...");

                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var anioMes = int.Parse(DateTime.Now.ToString("yyyyMM"));

                await Task.WhenAll(
                    mediator.Send(new GenerarAfiliadosCommand(anioMes), stoppingToken),
                    mediator.Send(new GenerarContratosCommand(anioMes), stoppingToken),
                    mediator.Send(new GenerarCuotaMonetariaCommand(anioMes), stoppingToken),
                    mediator.Send(new GenerarFondoLey115Command(anioMes), stoppingToken),
                    mediator.Send(new GenerarFondoLeyFoninezeCommand(anioMes), stoppingToken),
                    mediator.Send(new GenerarFondoLeyFoninez2Command(anioMes), stoppingToken),
                    mediator.Send(new GenerarFondoLeyFosfecCommand(anioMes), stoppingToken),
                    mediator.Send(new GenerarFondoLeyFovisCommand(anioMes), stoppingToken),
                    mediator.Send(new GenerarSubsidioEspecieCommand(anioMes), stoppingToken)
                );

                Console.WriteLine($"[{DateTime.Now}] Todos los archivos generados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");
            }

            await Task.Delay(TimeSpan.FromMinutes(intervalo), stoppingToken);
        }
    }
}