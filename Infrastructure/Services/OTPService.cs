using Domain.IRepositories;
using Microsoft.Extensions.Configuration;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static Shared.ResultExtensionMethods;

namespace Infrastructure.Services
{
    public class OTPService : IOTPService
    {
        private readonly IConfiguration _config;
        public OTPService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async Task<string> GenerateOTP()
        {
            Random random = new Random();
            string otp = "";
            for (int i = 0; i < 4; i++)
            {
                int temp = random.Next(10);
                otp += temp;
            }
            return otp;
        }

        public async Task<CommandResponse> SendMail(SendMailRequest request)
        {
            string mailFrom = _config.GetValue<string>("SendVerifyMailLinks:MailFrom");
            string mailPass = _config.GetValue<string>("SendVerifyMailLinks:MailPass");
            string smtp = _config.GetValue<string>("SendVerifyMailLinks:Smtp");
            int port = Convert.ToInt32(_config.GetValue<string>("SendVerifyMailLinks:SmtpPort"));


            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailFrom);
                    mail.To.Add(request.userMail);
                    mail.Subject = request.subject;
                    mail.IsBodyHtml = true;
                    if (request.body != null)
                    {
                        mail.Body = request.body;
                    }
                    else if (request.AlternateView != null)
                    {
                        mail.AlternateViews.Add(request.AlternateView);
                    }
                    else
                    {
                        return await Fail("Mail Body Can't be blank");
                    }

                    using (SmtpClient smtpClient = new SmtpClient(smtp, port))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential(mailFrom, mailPass);

                        smtpClient.Send(mail);
                    }
                }

                return await Ok("Mail was successfully sent");


            }
            catch (Exception ex)
            {
                return await Fail(ex.Message);
            }
        }
    }
}
