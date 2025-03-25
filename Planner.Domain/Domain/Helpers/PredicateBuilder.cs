using System.Linq.Expressions;
using Planner.Domain.Domain.Helpers.Extensions;

namespace Planner.Domain.Domain.Helpers;

public class PredicateBuilder<T>
{
    private Expression<Func<T, bool>> _predicate;

    public PredicateBuilder()
    {
        _predicate = x => true;
    }

    public PredicateBuilder<T> And(Expression<Func<T, bool>> predicate)
    {
        _predicate = _predicate.CombineWith(predicate, Expression.AndAlso);
        return this;
    }
    
    public PredicateBuilder<T> Or(Expression<Func<T, bool>> predicate)
    {
        _predicate = _predicate.CombineWith(predicate, Expression.OrElse);
        return this;
    }
    
    public Expression<Func<T, bool>> Build()
    {
        return _predicate;
    }
}