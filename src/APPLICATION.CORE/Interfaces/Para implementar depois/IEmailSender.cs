using System.Threading.Tasks;

namespace APPLICATION.CORE.Interfaces
{
    interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
