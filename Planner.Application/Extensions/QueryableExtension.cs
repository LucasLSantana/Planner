using System.Linq.Expressions;

namespace Planner.Application.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<TMap> Map<TSource, TMap>(this IQueryable<TSource> query, Func<IMap<TSource, TMap>, Expression<Func<TSource, TMap>>> mapper)
        {
            return query.Select(mapper(new Map<TSource, TMap>()));
        }
    }

    public interface IMap<T, TOut>
    {
    }

    public class Map<T, TOut> : IMap<T, TOut>
    {
    }
}