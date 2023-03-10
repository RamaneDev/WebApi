using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class SpecificationEvaluator<T> where T : BaseEntities
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        public static IQueryable<T> ApplySecification(ISpecification<T> spec, DbContext context)
        {
            return GetQuery(context.Set<T>().AsQueryable(), spec);
        }
    }
}
