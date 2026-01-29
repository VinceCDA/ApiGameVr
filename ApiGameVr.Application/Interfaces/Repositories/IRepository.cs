using ApiGameVr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiGameVr.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
