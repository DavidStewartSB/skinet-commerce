
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

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = 
            new List<Expression<Func<T, object>>>();

            protected void AddInclude(Expression<Func<T, object>> includeExpression) {
                Includes.Add(includeExpression);
            }
    }
}