using FluentValidation;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest<CommandResponse>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
    public class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidation()
        {
        }
    }
}
