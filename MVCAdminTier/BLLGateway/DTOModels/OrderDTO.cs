using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLLGateway.DTOModels
{
    //CRUD functionallity.
    public class OrderDTO : IGenericDTO
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
        [Display(Name = "OrderLines")]
        public IEnumerable<OrderLineModelDTO> OrderLine { get; set; }

        [Display(Name = "identification")]
        public int Id { get; set; }

        [Display(Name = "Customer identifikation")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer name")]
        public string CustomerName { get; set; }

        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Shipping date")]
        public DateTime ShippedDate { get; set; }

        [Display(Name = "Summarized purchase")]
        public decimal SumPurchase { get; set; }

        [Display(Name = "Shipping cost")]
        public decimal Shipping { get; set; }

        [Display(Name = "Total cost")]
        public decimal SumShipping { get; set; }
    }
}
