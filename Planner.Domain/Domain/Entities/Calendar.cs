using OneOf;
using Planner.Domain.Domain.Helpers;
using Planner.Domain.Domain.Helpers.OneOfErrors;

namespace Planner.Domain.Domain.Entities;

public class Calendar
{
    protected Calendar(Guid userId, DateTime start, DateTime finish, Enums.LeaveType leaveType)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Start = start;
        Finish = finish;
        LeaveType = leaveType;
        LeaveStatus = Enums.LeaveStatus.Pending;
        Delete = false;
    }

    public Calendar()
    {
        LeaveStatus = Enums.LeaveStatus.Pending;
        Delete = false;
    }

    public static OneOf<Calendar, CalendarError> New(Guid userId, DateTime start, DateTime finish, Enums.LeaveType leaveType)
    {
        if (finish < start)
            return CalendarError.InvalidDates("Finish date cannot be earlier than start date.");
        return new Calendar(userId, start, finish, leaveType);
    }
    
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public virtual User User { get; private set; }
    public DateTime Start { get; private set; }
    public DateTime Finish { get; private set; }
    public Enums.LeaveType LeaveType { get; private set; }
    public Enums.LeaveStatus LeaveStatus { get; private set; }
    public bool Delete { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public Guid? DeletedBy { get; private set; }

    public OneOf<Calendar, CalendarError> UpdateStartFinish(DateTime start, DateTime finish)
    {
        if (finish < start)
            return CalendarError.InvalidDates("Finish date cannot be earlier than start date.");

        Start = start;
        Finish = finish;

        return this;
    }

    public OneOf<Calendar, CalendarError> UpdateLeaveStatus(Enums.LeaveStatus leaveStatus)
    {
        LeaveStatus = leaveStatus;
        return this; 
    }

    public OneOf<Calendar, CalendarError> MarkAsDeleted(Guid deletedBy)
    {
        Delete = true;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = deletedBy;

        return this;
    }
}