﻿using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands
{
    public class SendEmailConfirmationCommand : IRequest<CommandResponse>
    {
        public string UserId { get; set; }
    }
}
