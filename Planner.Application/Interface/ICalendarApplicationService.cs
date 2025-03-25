using OneOf;
using Planner.Application.Application.DTOs;
using Planner.Domain.Domain.Entities;
using Planner.Domain.Domain.Helpers.OneOfErrors;

namespace Planner.Application.Interface;

public interface ICalendarApplicationService
{
    Task<OneOf<Guid, CalendarError>> CreateAsync(CalendarDto calendar);
    Task UpdateAsync(CalendarDto calendar);
    Task UpdateResetPasswordAsync(CalendarDto calendar);
    Task UpdateUserAdminAsync(CalendarDto calendar);
    Task UpdateUserActiveAsync(CalendarDto calendar);
    Task DeleteAsync(Guid id);
    Task<Calendar> GetByIdAsync(Guid id);
    Task<IEnumerable<Calendar>> GetCalendarAsync();
}