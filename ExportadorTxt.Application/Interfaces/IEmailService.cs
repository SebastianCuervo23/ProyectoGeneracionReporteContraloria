
namespace ExportadorTxt.Aplication.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmail(string emailReceptor, string tema, string cuerpo);
    }
}