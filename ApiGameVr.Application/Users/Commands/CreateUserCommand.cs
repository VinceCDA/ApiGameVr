using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Email { get; set; } = string.Empty;
        public string Pseudo { get; set; } = string.Empty;
    }
}
