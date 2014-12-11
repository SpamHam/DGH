using System.Collections.Generic;
using System.Web.Mvc;
using BLLGateway.DTOModels;

namespace MVC_DGHAdmin.Models
{
    public class OrderLineViewModels
    {
        public OrderLineDTO OrderLine { get; set; } 
        public IEnumerable<ProductDTO> Product { get; set; } 
        public SelectList DropProduct { get; set; }
    }
}