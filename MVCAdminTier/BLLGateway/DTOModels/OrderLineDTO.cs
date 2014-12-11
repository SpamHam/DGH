
using System.ComponentModel.DataAnnotations;

namespace BLLGateway.DTOModels
{
    //CRUD functionallity.
    public class OrderLineDTO : IGenericDTO
    {
        [Display(Name = "Order identification")]
        public int OrderId { get; set; }
                
        [Display(Name = "Product identification")]
        public int ProductId { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }

                       
        [Display(Name = "Total")]
        public decimal LineTotal { get; set; }

        [Display(Name = "Identification")]
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
