using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId , int? typeId) : base(x =>
            (!brandId.HasValue || x.ProductBrandId== brandId) && (!typeId.HasValue || x.ProductTypeId== typeId)
        )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            


            if (!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;

                }
            }
        }

    public ProductsWithTypesAndBrandsSpecification(int id):base(x=>x.Id == id)
    {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
    }


    }
}