using ApiGameVr.Application.Interfaces.Repositories;
using ApiGameVr.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<User> AddAsync(User entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
