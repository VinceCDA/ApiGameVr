using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Query
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IReadOnlyList<ApplicationUser>>
    {
        private readonly IApplicationUserRepository _userRepository;
        public GetUsersQueryHandler(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IReadOnlyList<ApplicationUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
