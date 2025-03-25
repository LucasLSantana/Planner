using OneOf;
using Planner.Domain.Domain.Helpers.OneOfErrors;

namespace Planner.Domain.Domain.Helpers.Extensions;

public static class OneOfExtensions
{
    public static bool IsSuccess<TResult>(this OneOf<TResult, CalendarError> obj) => obj.IsT0;
    public static TResult GetSuccessResult<TResult>(this OneOf<TResult, CalendarError> obj) => obj.AsT0;

    public static bool IsError<TResult>(this OneOf<TResult, CalendarError> obj) => obj.IsT1;
    public static CalendarError GetErrorResult<TResult>(this OneOf<TResult, CalendarError> obj) => obj.AsT1;
}