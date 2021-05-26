using Mantasflowers.Contracts.Email.Request;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(SendEmailRequest request);
    }
}