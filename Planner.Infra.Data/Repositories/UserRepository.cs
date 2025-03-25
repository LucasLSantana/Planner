using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planner.Domain.Domain.Entities;
using Planner.Domain.Domain.Interfaces.Repositories;
using Planner.Infra.Data.Data;

namespace Planner.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{

    private readonly PlannerDbContext _context;

    public UserRepository(PlannerDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(User entity)
    {
        await _context.User.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.User.FindAsync(id);
        if (entity is null) return;
        _context.User.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> AsQueryable()
    {
        return await _context.User.Take(50).ToListAsync();
    }
    
    public async Task<User> FindWithPredicate(Expression<Func<User, bool>> predicate)
    {
        return await _context.User.FirstOrDefaultAsync(predicate);
    }
    
    public async Task<IEnumerable<User>> FindListWithPredicate(Expression<Func<User, bool>> predicate)
    {
        return await _context.User.Where(predicate).ToListAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.User.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task UpdateAsync(User entity)
    {
        _context.User.Update(entity);
        await _context.SaveChangesAsync();
    }
}
