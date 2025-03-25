using OneOf;
using Planner.Application.Application.DTOs;
using Planner.Application.Interface;
using Planner.Domain.Domain.Entities;
using Planner.Domain.Domain.Helpers.Extensions;
using Planner.Domain.Domain.Helpers.OneOfErrors;
using Planner.Domain.Domain.Interfaces.Services;

namespace Planner.Application.Application;

public class CalendarApplicationService : ICalendarApplicationService
{
    private readonly ICalendarService _service;

    public CalendarApplicationService(ICalendarService service)
    {
        _service = service;
    }

    public async Task<OneOf<Guid, CalendarError>> CreateAsync(CalendarDto calendar)
    {
        try
        {
            var entity = Calendar.New( calendar.UserId, calendar.Start, calendar.Finish, calendar.LeaveType);
            if (entity.IsSuccess())
            {
                return await _service.CreateAsync(entity.AsT0);
            }
            return entity.AsT1;
        }
        catch (Exception e)
        {
            return CalendarError.InvalidDates(e.Message);
        }
    }

    public Task UpdateAsync(CalendarDto calendar)
    {
        throw new NotImplementedException();
    }

    public Task UpdateResetPasswordAsync(CalendarDto calendar)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAdminAsync(CalendarDto calendar)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserActiveAsync(CalendarDto calendar)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Calendar> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Calendar>> GetCalendarAsync()
    {
        throw new NotImplementedException();
    }
}