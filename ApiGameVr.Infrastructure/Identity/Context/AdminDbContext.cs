using ApiGameVr.Domain.Entities;
using ApiGameVr.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Infrastructure.Identity.Context
{
    public class AdminDbContext : IdentityDbContext<IdentityAdminUser>
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityAdminUser>(e => e.HasOne<ApplicationUser>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
