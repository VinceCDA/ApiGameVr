using ApiGameVr.Application.Features.Users.Commands.Create;
using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.AdminUsers.Commands.Create
{
    public class CreateAdminUserCommandHandler : IRequestHandler<CreateAdminUserCommand, Unit>
    {
        private readonly IAdminUserRepository _adminUserRepository;
        public CreateAdminUserCommandHandler(IAdminUserRepository adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }

        public async Task<Unit> Handle(CreateAdminUserCommand request, CancellationToken cancellationToken)
        {
            AdminUser adminUser = new AdminUser { Email = request.Email};
            await _adminUserRepository.CreateAsync(adminUser,request.Password);
            return Unit.Value;
        }
    }
}
