using ExportadorTxt.Aplication.Interfaces;
using ExportadorTxt.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace ExportadorTxt.Infrastructure.Infraestructura.Servicios;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task EnviarEmail(string emailReceptor, string tema, string cuerpo)
    {
        var emailEmisor = _configuration["CONFIGURACIONES_EMAIL:SenderEmail"] ?? throw new InvalidOperationException("SenderEmail no configurado.");
        var host = _configuration["CONFIGURACIONES_EMAIL:HOST"] ?? throw new InvalidOperationException("HOST SMTP no configurado.");
        var puertoStr = _configuration["CONFIGURACIONES_EMAIL:PUERTO"] ?? throw new InvalidOperationException("PUERTO SMTP no configurado.");

        using var smtpClient = new SmtpClient(host, int.Parse(puertoStr))
        {
            EnableSsl = false,
            UseDefaultCredentials = false
        };

        using var mensaje = new MailMessage(emailEmisor, emailReceptor, tema, cuerpo);

        try
        {
            await smtpClient.SendMailAsync(mensaje);
        }
        catch (SmtpException ex)
        {
            Console.WriteLine(ex.StatusCode);
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}