using BuyMe.Application.Common.Interfaces;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure
{
    public class EmailService: IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {

            var client = new SmtpClient("smtp.mailtrap.io", 587)
            {
                Credentials = new NetworkCredential("3b72fbfbebf241", "e32561442e7aed"),
                EnableSsl = true
            };
            await client.SendMailAsync("from@example.com", email, subject, body);

        }
    }
}
