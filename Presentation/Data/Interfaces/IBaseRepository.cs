﻿using Presentation.Models;
using System.Linq.Expressions;

namespace Presentation.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<RepositoryResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<RepositoryResult> CreateAsync(TEntity entity);
        Task<RepositoryResult> DeleteAsync(TEntity entity);
        Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<RepositoryResult<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<RepositoryResult> UpdateAsync(TEntity entity);
    }
}