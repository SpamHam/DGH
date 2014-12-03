using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities_Converter
{
    class ProductConverter
    {
        
        public static Product ToProduct(ProductDTO DTO)
        {
            var product = new Product()
            {
                id = DTO.id,
                name = DTO.name,
                productNumber = DTO.productNumber,
                color = DTO.color,
                stock = DTO.stock,
                salesPrice = DTO.salesPrice,
                categoryId = DTO.categoryId,
                imageUrl = DTO.imageUrl,
                active = DTO.active
            };
            return product;
        }
        public static ProductDTO ToProductDTO(Product Entity)
        {
            var productDTO = new ProductDTO()
            {
                id = Entity.id,
                name = Entity.name,
                productNumber = Entity.productNumber,
                color = Entity.color,
                stock = Entity.stock,
                salesPrice = Entity.salesPrice,
                categoryId = Entity.categoryId,
                imageUrl = Entity.imageUrl,
                active = Entity.active

            };
            return productDTO;
        }
    }
}
