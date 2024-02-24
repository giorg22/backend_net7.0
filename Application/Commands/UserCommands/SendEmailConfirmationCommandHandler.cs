using Application.Shared;
using Azure.Identity;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static Shared.ResultExtensionMethods;

namespace Application.Commands.UserCommands
{
    public class SendEmailConfirmationCommandHandler : CommandHandler<SendEmailConfirmationCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly IOTPService _otpService;

        public SendEmailConfirmationCommandHandler(UserManager<User> userManager, IOTPService otpService)
        {
            _userManager = userManager;
            _otpService = otpService;
        }
        public override async Task<CommandResponse> Handle(SendEmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return await Fail(ErrorCode.UserNotFound);
            string otp = await _otpService.GenerateOTP();
            user.UpdateEmailConfirmationCode(otp);
            var a = await _userManager.UpdateAsync(user);
            string htmlBody = "<html>" +
                         "<body>" +
                            $"<p>Hi {user.Firstname} {user.Lastname},</p>" +
                            "<p>We are happy you signed up for Morti.</p>" +
                            $"<p>Verification Code: {otp}</p>" +
                            $"<p>Welcome to morti!</p>" +
                            $"<p>The Morti team</p>" +
                        "</body>" +
                       "</html>";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
            var sendMailRequest = new SendMailRequest()
            {
                userMail = user.Email,
                subject = "Morti Email Verification",
                AlternateView = alternateView
            };
            return await _otpService.SendMail(sendMailRequest);
        }
    }
}
