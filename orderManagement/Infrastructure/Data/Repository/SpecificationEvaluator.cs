using System.Linq;
using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Specifications;
using orderManagement.Entities;

namespace orderManagement.Infrastructure.Data.Repository
{
    public class SpecificationEvaluator<TEntity> where TEntity:BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            // query
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            // sort query
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            // paging
            if (spec.IsPagingEnable)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            // <query> --> sequence to aggregate over.
            // <(current,include)> --> An accumulator function to apply to each element
            // <current> --> represent of the entity
            // <include> --> is going to be the expression of our include statement
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}