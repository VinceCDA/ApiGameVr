using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Commands.Delete
{
    public record DeleteUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
