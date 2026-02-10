using ApiGameVr.Application.Features.AdminUsers.Commands.Create;
using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Features.AdminUsers.Commands.Login
{
    public class LoginAdminUserCommandHandler : IRequestHandler<LoginAdminUserCommand, object>
    {
        private readonly IAdminUserRepository _adminUserRepository;
        public LoginAdminUserCommandHandler(IAdminUserRepository adminUserRepository) { 
         _adminUserRepository = adminUserRepository;
        }
        public async Task<object> Handle(LoginAdminUserCommand request, CancellationToken cancellationToken)
        {
            await _adminUserRepository.Login(request.Email,request.Password);
            return null;
        }
    }
}
