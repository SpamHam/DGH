using System;
using System.Collections.Generic;

namespace BLL.DTOModels
{
    //CRUD functionallity.
    public class OrderDTO: IGenericDTO
    {
        public int id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime shippedDate { get; set; }

        public decimal SumPurchase { get; set; }

        public decimal Shipping { get; set; }

        public decimal sumShipping { get; set; }
    }

    //specefik for presentation view.
    public class OrderModelDTO
    {
        public IEnumerable<OrderLineModelDTO> OrderLine { get; set; }

        public int id { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime shippedDate { get; set; }

        public decimal SumPurchase { get; set; }

        public decimal Shipping { get; set; }

        public decimal sumShipping { get; set; }
    }
}
