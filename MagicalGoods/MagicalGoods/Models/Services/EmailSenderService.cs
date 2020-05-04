using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;

namespace MagicalGoods.Models.Services
{
    public class EmailSenderService : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["SendGridKey"]);
            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("no-reply@magicalgoods.com", "Andrew and Ally");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);

        }
    }
}
