using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace orderManagement.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        // pagination
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnable { get; }
    }
}