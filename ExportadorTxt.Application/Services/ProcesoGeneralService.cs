using ExportadorTxt.Aplication.Interfaces;
using ExportadorTxt.Application;
using ExportadorTxt.Application.Commands;
using MediatR;
using Microsoft.Extensions.Options;
using System.Text;

public class ProcesoGeneralService
{
    private readonly ResultadoArchivos _resultadoArchivos;
    private readonly IEmailService _emailService;
    private readonly IMediator _mediator;
    private readonly EmailSettings _emailSettings;

    public ProcesoGeneralService(
        ResultadoArchivos resultadoArchivos,
        IEmailService emailService,
        IMediator mediator,
        IOptions<EmailSettings> options)
    {
        _resultadoArchivos = resultadoArchivos;
        _emailService = emailService;
        _mediator = mediator;
        _emailSettings = options.Value;
    }

    public async Task Ejecutar(CancellationToken stoppingToken)
    {
        try
        {
            Console.WriteLine($"[{DateTime.Now}] Iniciando proceso...");

            //var anioMes = int.Parse(DateTime.Now.AddMonths(-1).ToString("yyyyMM"));
            var anioMes = 202506; 

            await _mediator.Send(new GenerarAfiliadosCommand(anioMes), stoppingToken);
            await _mediator.Send(new GenerarContratosCommand(anioMes), stoppingToken);
            await _mediator.Send(new GenerarCuotaMonetariaCommand(anioMes), stoppingToken);
            await _mediator.Send(new GenerarFondoLey115Command(anioMes), stoppingToken);
            await _mediator.Send(new GenerarFondoLeyFoninezeCommand(anioMes), stoppingToken);
            await _mediator.Send(new GenerarFondoLeyFoninez2Command(anioMes), stoppingToken);
            await _mediator.Send(new GenerarFondoLeyFosfecCommand(anioMes), stoppingToken);
            await _mediator.Send(new GenerarFondoLeyFovisCommand(anioMes), stoppingToken);
            await _mediator.Send(new GenerarSubsidioEspecieCommand(anioMes), stoppingToken);

            var archivos = _resultadoArchivos.ObtenerTodos();

            var cuerpo = new StringBuilder();
            if (archivos.Count == 0)
            {
                cuerpo.AppendLine($"No se generaron archivos para el periodo {anioMes}. Favor validar.");
            }
            else
            {
                cuerpo.AppendLine($"Cordial saludo \n \n Me permito informar que se han generado exitosamente los siguientes archivos :\n ");
            }

            foreach (var archivo in archivos)
            {
                cuerpo.AppendLine($"\n- {archivo}");
                
            }          
            await _emailService.EnviarEmail(_emailSettings.EmailReceptor,$"GENERACION ARCHIVOS CONTRALORIA. {anioMes}",cuerpo.ToString());
            Console.WriteLine($"Proceso finalizado exitosamente.[{DateTime.Now}] ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");

        }
    }

}