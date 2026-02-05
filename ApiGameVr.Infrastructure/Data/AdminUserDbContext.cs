using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Infrastructure.Data
{
    public class AdminUserDbContext : IdentityDbContext<IdentityUser>
    {
        public AdminUserDbContext(DbContextOptions<AdminUserDbContext> options) : base(options) { }
    }
}
