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


using ExportadorTxt.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Text;

namespace ExportadorTxt.Infrastructure.Infraestructura;

public class ArchivoService<T> : IArchivoService<T>
{
    private readonly string? _rutaSalida;
    private readonly string _nombreArchivo;

    public ArchivoService(IConfiguration configuration)
    {
        _rutaSalida = configuration["RutaSalida"];
        _nombreArchivo = typeof(T).Name;
    }

    public async Task GenerarArchivoAsync(IEnumerable<T> datos)
    {
        var nombre = $"{_nombreArchivo}_{DateTime.Now:yyyyMMddHHmm}.txt";
        var rutaCompleta = Path.Combine(_rutaSalida!, nombre);

        var propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var lineas = datos.Select(item =>
            string.Join("|", propiedades.Select(p =>
            {
                var valor = p.GetValue(item);
                return valor is DateTime dt ? dt.ToString("yyyy-MM-dd") :
                       valor?.ToString() ?? string.Empty;
            })));

        await File.WriteAllLinesAsync(rutaCompleta, lineas, Encoding.UTF8);
    }
}*/
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