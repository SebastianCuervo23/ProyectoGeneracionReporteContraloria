using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Application.UseCases;
using ExportadorTxt.Infrastructure.Infraestructura;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExportadorTxt.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<ISubsidioEspecieRepositorio, SubsidioEspecieRepositorio>();
builder.Services.AddSingleton<IArchivoService, ArchivoService>();
builder.Services.AddSingleton<GenerarArchivoSubsidioUseCase>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
/*using var scope = host.Services.CreateScope();

var useCase = scope.ServiceProvider.GetRequiredService<GenerarArchivoSubsidioUseCase>();

int anioMes = 202401;

await useCase.EjecutarAsync(anioMes);

Console.WriteLine("Proceso finalizado.");

Console.ReadLine();

*/host.Run();
