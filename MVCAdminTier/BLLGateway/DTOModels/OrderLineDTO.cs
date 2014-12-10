
using System.ComponentModel.DataAnnotations;

namespace BLLGateway.DTOModels
{
    //CRUD functionallity.
    public class OrderLineDTO : IGenericDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }

        public decimal LineTotal { get; set; }

        public int id { get; set; }
    }

    //For presentation view.
    public class OrderLineModelDTO
    {
        [Display(Name = "Identification")]
        public int Id { get; set; }

        [Display(Name = "Product Identification")]
        public int ProductId { get; set; }

        [Display(Name = "Order Identification")]
        public int OrderId { get; set; }

        [Display(Name = "Product name")]
        public string ProductName { get; set; }

        [Display(Name = "Product picture")]
        public string ProductPicture { get; set; }

        [Display(Name = "Product price")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Display(Name = "Total price")]
        public decimal LineTotal { get; set; }
    }
}
