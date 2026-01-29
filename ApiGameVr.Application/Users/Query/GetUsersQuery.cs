using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Users.Query
{
    public class GetUsersQuery : IRequest<IReadOnlyList<User>>
    {
    }
}
