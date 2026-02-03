using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Email { get; set; } = string.Empty;
        public string Pseudo { get; set; } = string.Empty;
    }
}
