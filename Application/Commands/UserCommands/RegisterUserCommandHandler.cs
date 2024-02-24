using Application.Shared;
using Domain.Entities;
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
    public class RegisterUserCommandHandler : CommandHandler<RegisterUserCommand>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public override async Task<CommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                UserName = request.Email,
                BirthDate = request.BirthDate
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return await Fail(result.Errors);
            return await Ok(user.Id);
        }
    }
}
