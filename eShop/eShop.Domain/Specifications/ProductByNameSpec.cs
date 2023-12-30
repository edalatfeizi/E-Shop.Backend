using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Specifications
{
    public class ProductByNameSpec : Specification<Product>
    {
        public ProductByNameSpec(string productName) 
        {
            Query.Where(x => x.Name == productName);
        }
    }
}
