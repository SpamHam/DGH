using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DGHAdmin.Models
{
    public class ProductViewModels
    {
        IEnumerable<CategoryDTO> categories { get; set; }
        IEnumerable<ProductDTO> products { get; set; }
    }
}