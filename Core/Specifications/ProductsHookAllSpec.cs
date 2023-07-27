using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsHookAllSpec : BaseSpecification<Product>
    {
        public ProductsHookAllSpec()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsHookAllSpec(int id) : base(x => x.Id == id) //Segundo parametro do criteria é um bool, nesse caso retornou true
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}