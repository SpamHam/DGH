using System;

namespace BLL.DTOModels
{
    public class OrderDTO: IGenericDTO
    {
        public int id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime shippedDate { get; set; }

        public decimal SumPurchase { get; set; }

        public int Shipping { get; set; }

        public int sumShipping { get; set; }
    }
}
