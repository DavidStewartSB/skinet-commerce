using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infra.data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
         public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, 
            ISpecifications<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null) {
                query = query.Where(spec.Criteria); //p => p.ProductTypeId == id;
            }
            if(spec.OrderBy != null) {
                query = query.OrderBy(spec.OrderBy);
            }
            if(spec.OrderByDesc != null) {
                query = query.OrderByDescending(spec.OrderByDesc);
            }
            if(spec.IsPagingEnabnle) {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
           
        }
    }
}