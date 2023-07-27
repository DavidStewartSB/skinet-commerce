
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria; //Responsável por pegar um ID espeficio 
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take   { get; private set; }

        public int Skip   { get; private set; }

        public bool IsPagingEnabnle   { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) 
        {
            OrderBy = orderByExpression;    
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression) 
        {
            OrderByDesc = orderByDescExpression;    
        }

        protected void ApplyPagin(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabnle = true;
        }
    }
}