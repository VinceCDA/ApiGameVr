using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { 
                entity.HasKey(x => x.Id); 
                entity.Property(x => x.Email).IsRequired();
                entity.Property(x => x.Pseudo).IsRequired();
            }

            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
