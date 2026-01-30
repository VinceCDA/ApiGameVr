using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.Id);
            await _userRepository.DeleteAsync(user);
            return 1;
        }
    }
}
