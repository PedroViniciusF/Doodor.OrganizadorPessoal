using System.Threading.Tasks;

namespace Doodor.OrganizadorPessoal.Infra.CrossCutting.Identity
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
