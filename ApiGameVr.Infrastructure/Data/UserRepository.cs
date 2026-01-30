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

        public async Task DeleteAsync(User entity)
        {
            User user = await GetByIdAsync(entity.Id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            return await _context.TestUsers.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            User? user = await _context.TestUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
