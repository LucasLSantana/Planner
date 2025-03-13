﻿using System.Linq.Expressions;
using Planner.Domain.Domain.Entities;

namespace Planner.Domain.Domain.Interfaces.Services.Base;

public interface IServiceBase<T>
{
    Task<Guid> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T> GetByIdAsync(Guid id);
    Task<IQueryable<T>> AsQueryable();
    Task<T> FindWithPredicate(Expression<Func<User, bool>> predicate);
    Task<IEnumerable<T>> FindListWithPredicate(Expression<Func<User, bool>> predicate);
}
