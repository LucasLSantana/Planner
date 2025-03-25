namespace Planner.Domain.Domain.Helpers.OneOfErrors;

public class CalendarError
{
    public string Message { get; }

    private CalendarError(string message)
    {
        Message = message;
    }

    public static CalendarError InvalidDates(string message) => new CalendarError(message);
}