using System;
using System.Collections.Generic;
using BLLGateway.DTOModels;

namespace MVC_DGHAdmin.Models
{
    public class OrderModel
    {
        public OrderDTO order { get; set; }
        public OrderLineDTO orderLine { get; set; }
        public ProductDTO product { get; set; }
        public CustomerDTO customer { get; set; }
    }
}