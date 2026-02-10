using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using ApiGameVr.Infrastructure.Identity.Context;
using ApiGameVr.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Infrastructure.Data
{
    public class UserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<ApplicationUser> AddAsync(ApplicationUser entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(ApplicationUser entity)
        {
            ApplicationUser user = await GetByIdAsync(entity.Id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<ApplicationUser>> GetAllAsync()
        {
            return await _context.TestUsers.ToListAsync();
        }

        public async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            ApplicationUser? user = await _context.TestUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
