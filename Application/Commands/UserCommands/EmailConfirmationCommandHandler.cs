using Application.Shared;
using Azure.Identity;
using Domain.Entities;
using Domain.IRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.ResultExtensionMethods;

namespace Application.Commands.UserCommands
{
    public class EmailConfirmationCommandHandler : CommandHandler<EmailConfirmationCommand>
    {
        private readonly UserManager<User> _userManager;

        public EmailConfirmationCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public override async Task<CommandResponse> Handle(EmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return await Fail(ErrorCode.UserNotFound);
            if (user.EmailConfirmationCode != request.ConfirmationCode)
                return await Fail(ErrorCode.InvalidEmailVerificationCode);
            user.ConfirmEmail();
            await _userManager.UpdateAsync(user);
            return await Ok();
        }
    }
}
