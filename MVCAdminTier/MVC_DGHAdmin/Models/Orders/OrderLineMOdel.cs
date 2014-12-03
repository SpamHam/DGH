using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DGHAdmin.Models.Orders
{
    public class OrderLineModel
    {
        public int id { get; set; }

        public String ProductName { get; set; }

        public String ProductPicture { get; set; }

        public Decimal ProductPrice { get; set; }

        public int Amount { get; set; }

        public decimal LineTotal { get; set; }
    }
}