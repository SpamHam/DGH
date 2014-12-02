using System;
using System.Collections.Generic;
using BLLGateway.DTOModels;

namespace MVC_DGHAdmin.Models
{
    public class OrderModel
    {
        public IEnumerable<OrderDTO> order { get; set; }
        public IEnumerable<OrderLineDTO> orderLine { get; set; }
        public IEnumerable<ProductDTO> product { get; set; }
        public IEnumerable<CustomerDTO> customer { get; set; }
    }
}