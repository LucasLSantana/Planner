using System.Linq.Expressions;
using Planner.Domain.Domain.Entities;
using Planner.Domain.Domain.Interfaces;
using Planner.Domain.Domain.Interfaces.Repositories;

namespace Planner.Domain.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(User entity)
    {
        return await _repository.CreateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IQueryable<User>> AsQueryable()
    {
        return await _repository.AsQueryable();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(User entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task<User> FindWithPredicate(Expression<Func<User, bool>> predicate)
    {
        return await _repository.FindWithPredicate(predicate);
    }

    public async Task<IEnumerable<User>> FindListWithPredicate(Expression<Func<User, bool>> predicate)
    {
        return await _repository.FindListWithPredicate(predicate);
    }
}
