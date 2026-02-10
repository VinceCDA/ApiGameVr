using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        public Task<bool> AuthenticateAsync();
    }
}
