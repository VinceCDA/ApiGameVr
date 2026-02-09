using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.AdminUsers.Commands.Create
{
    public class CreateAdminUserCommand : IRequest<Unit>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
