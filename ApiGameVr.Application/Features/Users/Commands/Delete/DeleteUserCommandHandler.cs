using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IApplicationUserRepository _userRepository;
        public DeleteUserCommandHandler(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userRepository.GetByIdAsync(request.Id);
            await _userRepository.DeleteAsync(user);
            return Unit.Value;
        }
    }
}
