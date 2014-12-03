using System.Collections.Generic;

namespace MVC_DGHAdmin.Models.Orders
{
    public class OModel
    {
        public OrderModel Order { get; set; }
        public List<OrderLineModel> OrderLine { get; set; }
    }
}