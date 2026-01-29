using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Query
{
    public class GetUsersQuery : IRequest<IReadOnlyList<User>>
    {
    }
}
