using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsHookAllSpec : BaseSpecification<Product>
    {
        public ProductsHookAllSpec(string sort, int? brandId, int? typeid) 
        : base(x => (!brandId.HasValue || x.ProductBrandId == brandId) && (!typeid.HasValue || x.ProductTypeId == typeid))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort)) 
            {
                switch(sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsHookAllSpec(int id) : base(x => x.Id == id) //Segundo parametro do criteria é um bool, nesse caso retornou true
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}