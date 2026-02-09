using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IApplicationUserRepository _userRepository;
        public CreateUserCommandHandler(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
                var user = new ApplicationUser(request.Email, request.Pseudo);
                await _userRepository.AddAsync(user);
                return Unit.Value;
        }
    }
}
