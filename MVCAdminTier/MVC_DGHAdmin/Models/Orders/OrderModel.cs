using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DGHAdmin.Models.Orders
{
    public class OrderModel
    {
        public int id { get; set; }

        public String CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime shippedDate { get; set; }

        public decimal SumPurchase { get; set; }

        public int Shipping { get; set; }

        public int sumShipping { get; set; }
    }
}