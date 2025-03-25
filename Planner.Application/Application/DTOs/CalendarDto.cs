using Planner.Domain.Domain.Helpers;

namespace Planner.Application.Application.DTOs;

public class CalendarDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public Enums.LeaveType LeaveType { get; set; }
    public Enums.LeaveStatus LeaveStatus { get; set; }
    public bool Delete { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
}