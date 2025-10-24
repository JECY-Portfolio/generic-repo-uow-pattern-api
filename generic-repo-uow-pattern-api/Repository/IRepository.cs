﻿using generic_repo_pattern_api.Data;
using Microsoft.EntityFrameworkCore;

namespace generic_repo_pattern_api.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void SetDbContext(MyDbContext dbContext);
    }
}
