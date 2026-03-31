/*namespace ExportadorTxt.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

*/
using ExportadorTxt.Application.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ExportadorTxt.Worker;

public class Worker : BackgroundService
{
    private readonly GenerarArchivoSubsidioUseCase _useCase;
    private readonly IConfiguration _config;

    public Worker(
        GenerarArchivoSubsidioUseCase useCase,
        IConfiguration config)
    {
        _useCase = useCase;
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

                var anioMes = int.Parse(DateTime.Now.ToString("yyyyMMddmm"));

                await _useCase.EjecutarAsync(anioMes);

                Console.WriteLine($"[{DateTime.Now}] Proceso finalizado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            await Task.Delay(TimeSpan.FromMinutes(intervalo), stoppingToken);
        }
    }
}