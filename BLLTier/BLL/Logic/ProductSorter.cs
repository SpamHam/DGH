using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class ProductSorter
    {
        public static IEnumerable<ProductDTO> getActiveProducts(IEnumerable<ProductDTO> allProducts)
        {
            try
            {
                IEnumerable<ProductDTO> activeProducts = new ProductDTO[] { };
                foreach (var prod in allProducts)
                {
                    if (prod.active) activeProducts = activeProducts.Concat(new[] { prod });
                }
                return activeProducts;
            }
            catch (NullReferenceException) { throw new Exception("Could not load products"); }
        }
    }
}