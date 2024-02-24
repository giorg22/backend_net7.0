using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands
{
    public class EmailConfirmationCommand : IRequest<CommandResponse>
    {
        public string UserId { get; set; }
        public string ConfirmationCode { get; set; }
    }
}
