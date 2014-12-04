using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DGHAdmin.Models
{
    public class ProductViewModels
    {
       public IEnumerable<CategoryDTO> categories { get; set; }
       public IEnumerable<ProductDTO> products { get; set; }
       public SelectList dropCategories { get; set; }
       public ProductDTO product { get; set; }
       public CategoryDTO category { get; set; }
    }
}