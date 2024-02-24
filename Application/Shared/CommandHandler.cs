using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared
{
    public abstract class CommandHandler<Command> : IRequestHandler<Command, CommandResponse> where Command : IRequest<CommandResponse>
    {
        public abstract Task<CommandResponse> Handle(Command request, CancellationToken cancellationToken);
    }
}
