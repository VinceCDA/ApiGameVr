using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Query
{
    public record GetUsersQuery : IRequest<IReadOnlyList<ApplicationUser>>
    {
    }
}
