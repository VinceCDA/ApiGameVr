using ApiGameVr.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Infrastructure.Identity.Users
{
    public class IdentityAdminUser : IdentityUser
    {
        public AdminUser User { get; set; }
    }
}
