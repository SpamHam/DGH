using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DGHAdmin.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}