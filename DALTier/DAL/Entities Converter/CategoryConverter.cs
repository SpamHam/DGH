using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities_Converter
{
    class CategoryConverter
    {
        public static Category ToCategory(CategoryDTO categoryDTO)
        {
            var category = new Category()
            {
               id = categoryDTO.id,
               categoryName = categoryDTO.categoryName
            };
            return category;
        }
        public static CategoryDTO ToCategoryDTO(Category category)
        {
            var categoryDTO = new CategoryDTO()
            {
                id = category.id,
                categoryName = category.categoryName
            };

            return categoryDTO;
        }
    }
}
