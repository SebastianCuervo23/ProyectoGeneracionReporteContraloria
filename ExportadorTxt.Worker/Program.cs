using ExportadorTxt.Application.Handlers;
using ExportadorTxt.Application.Interfaces;
using ExportadorTxt.Domain.Entidades;
using ExportadorTxt.Infrastructure.Infraestructura;
using ExportadorTxt.Worker;

var builder = Host.CreateApplicationBuilder(args);

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AfiliadosHandler).Assembly));

// Repositorios
builder.Services.AddScoped<IRepositorio<Afiliados>, AfiliadosRepositorio>();
builder.Services.AddScoped<IRepositorio<Contratos>, ContratosRepositorio>();
builder.Services.AddScoped<IRepositorio<CuotaMonetaria>, CuotaMonetariaRepositorio>();
builder.Services.AddScoped<IRepositorio<FondoLey115>, FondoLey115Repositorio>();
builder.Services.AddScoped<IRepositorio<FondoLeyFoniñez>, FondoLeyFoninezeRepositorio>();
builder.Services.AddScoped<IRepositorio<FondoLeyFoniñez2>, FondoLeyFoninez2Repositorio>();
builder.Services.AddScoped<IRepositorio<FondoLeyFosfec>, FondoLeyFosfecRepositorio>();
builder.Services.AddScoped<IRepositorio<FondoLeyFovis>, FondoLeyFovisRepositorio>();
builder.Services.AddScoped<IRepositorio<SubsidioEspecie>, SubsidioEspecieRepositorio>();

// Servicios de archivo
builder.Services.AddScoped<IArchivoService<Afiliados>, ArchivoService<Afiliados>>();
builder.Services.AddScoped<IArchivoService<Contratos>, ArchivoService<Contratos>>();
builder.Services.AddScoped<IArchivoService<CuotaMonetaria>, ArchivoService<CuotaMonetaria>>();
builder.Services.AddScoped<IArchivoService<FondoLey115>, ArchivoService<FondoLey115>>();
builder.Services.AddScoped<IArchivoService<FondoLeyFoniñez>, ArchivoService<FondoLeyFoniñez>>();
builder.Services.AddScoped<IArchivoService<FondoLeyFoniñez2>, ArchivoService<FondoLeyFoniñez2>>();
builder.Services.AddScoped<IArchivoService<FondoLeyFosfec>, ArchivoService<FondoLeyFosfec>>();
builder.Services.AddScoped<IArchivoService<FondoLeyFovis>, ArchivoService<FondoLeyFovis>>();
builder.Services.AddScoped<IArchivoService<SubsidioEspecie>, ArchivoService<SubsidioEspecie>>();

// Worker
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();