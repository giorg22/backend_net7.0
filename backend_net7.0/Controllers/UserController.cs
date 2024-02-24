using Application.Commands.UserCommands;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace backend_net7._0.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<CommandResponse> Register([FromBody] RegisterUserCommand command) =>
            await _mediator.Send(command);
        [HttpPost("EmailConfirmation")]
        public async Task<CommandResponse> EmailConfirmation([FromBody] EmailConfirmationCommand command) =>
            await _mediator.Send(command);
        [HttpPost("SendEmailConfirmation")]
        public async Task<CommandResponse> SendEmailConfirmation([FromBody] SendEmailConfirmationCommand command) =>
            await _mediator.Send(command);
    }
}
