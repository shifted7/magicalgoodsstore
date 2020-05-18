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


        /// <summary>
        /// allows our site to send an email to our users. It implements send grid where a key is needed and sets up our messages to say it is from us. Adds defaulted settings where we can pass in the subject and the email we are sending to, the title of the email, and the html message
        /// </summary>
        /// <param name="email">who are sending the email to</param>
        /// <param name="subject">title of the email</param>
        /// <param name="htmlMessage">html message contents of the email</param>
        /// <returns></returns>
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
