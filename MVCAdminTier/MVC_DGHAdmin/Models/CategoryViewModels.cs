using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DGHAdmin.Models
{
    public class CategoryViewModels
    {
        public List<CategoryDTO> Category { get; set; }
        public CategoryDTO SelectedCategory { get; set; }

        public List<ProductDTO> Product { get; set; }
        public ProductDTO SelectedProduct { get; set; }

        public int count { get; set; }
    }
}