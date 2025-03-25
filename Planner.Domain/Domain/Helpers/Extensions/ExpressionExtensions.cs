using System.Linq.Expressions;

namespace Planner.Domain.Domain.Helpers.Extensions;

public static class ExpressionExtension
{
    public static Expression<Func<T, bool>> CombineWith<T>(
        this Expression<Func<T, bool>> first,
        Expression<Func<T, bool>> second,
        Func<Expression, Expression, Expression> combine)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        
        var body = combine(
            Expression.Invoke(first, parameter),
            Expression.Invoke(second, parameter)
        );

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}