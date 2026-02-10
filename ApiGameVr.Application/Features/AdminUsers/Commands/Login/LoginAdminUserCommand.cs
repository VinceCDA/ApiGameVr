using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.AdminUsers.Commands.Login
{
    public record LoginAdminUserCommand : IRequest<object>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
