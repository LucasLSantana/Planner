using System.Linq.Expressions;
using Planner.Domain.Domain.Entities;

namespace Planner.Domain.Domain.Interfaces.Repositories.Base;

public interface IRepositoryBase<T>
{
    Task<Guid> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> AsQueryable();
    Task<T> FindWithPredicate(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> FindListWithPredicate(Expression<Func<T, bool>> predicate);
}
