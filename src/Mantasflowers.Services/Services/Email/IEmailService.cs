using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(
            DateTime purchaseDate,
            string clientFullName,
            string clientEmail,
            string orderNumber,
            string orderUrl);
    }
}