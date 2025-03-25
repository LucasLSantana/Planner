using System.Linq.Expressions;
using Planner.Domain.Domain.Entities;
using Planner.Domain.Domain.Interfaces.Repositories;
using Planner.Domain.Domain.Interfaces.Services;

namespace Planner.Domain.Domain.Services;

public class CalendarService : ICalendarService
{
    private readonly ICalendarRepository _repository;

    public CalendarService(ICalendarRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(Calendar entity)
    {
        return await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(Calendar entity)
    {
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<Calendar> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<Calendar>> AsQueryable()
    {
        return await _repository.AsQueryable();
    }

    public async Task<Calendar> FindWithPredicate(Expression<Func<Calendar, bool>> predicate)
    {
        return await _repository.FindWithPredicate(predicate);
    }

    public async Task<IEnumerable<Calendar>> FindListWithPredicate(Expression<Func<Calendar, bool>> predicate)
    {
        return await _repository.FindListWithPredicate(predicate);
    }
}