using System.Collections.Generic;
using System.Web.Mvc;
using BLLGateway.DTOModels;

namespace MVC_DGHAdmin.Models
{
    public class OrderViewModels
    {
        public OrderDTO Order { get; set; }
        public IEnumerable<CustomerDTO> Customer { get; set; }
        public SelectList DropCustomer { get; set; }
    }
}