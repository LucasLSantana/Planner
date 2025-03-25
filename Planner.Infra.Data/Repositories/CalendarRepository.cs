using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planner.Domain.Domain.Entities;
using Planner.Domain.Domain.Interfaces.Repositories;
using Planner.Infra.Data.Data;

namespace Planner.Infra.Data.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly PlannerDbContext _context;

        public CalendarRepository(PlannerDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Calendar entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _context.Calendar.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(Calendar entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Calendar.Update(entity); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Calendar.FindAsync(id);
            if (entity == null) return;

            _context.Calendar.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Calendar> GetByIdAsync(Guid id)
        {
            return await _context.Calendar.FirstOrDefaultAsync(calendar => calendar.Id == id);
        }

        public async Task<List<Calendar>> AsQueryable()
        {
            return await _context.Calendar.Take(50).ToListAsync();
        }

        public async Task<Calendar> FindWithPredicate(Expression<Func<Calendar, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return await _context.Calendar.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Calendar>> FindListWithPredicate(Expression<Func<Calendar, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return await _context.Calendar.Where(predicate).ToListAsync();
        }
    }
}
