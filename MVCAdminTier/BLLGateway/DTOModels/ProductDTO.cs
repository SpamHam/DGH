using System.ComponentModel.DataAnnotations;
namespace BLLGateway.DTOModels
{
 public class ProductDTO: IGenericDTO
    {
        public int id { get; set; }
       [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        [Display(Name = "product number")]
        [Required(ErrorMessage = "product number is required")]
        public string productNumber { get; set; }
     [Required(ErrorMessage = "Color is required")]
        public string color { get; set; }
     [Required(ErrorMessage = "stock number is required")]
        public int stock { get; set; }
     [Display(Name = "sales price")]
     [Required(ErrorMessage = "Sales price is required")]
        public decimal salesPrice { get; set; }
        public int categoryId { get; set; }
     [Display(Name = "image url")]
        public string imageUrl { get; set; }
        public bool active { get; set; }

    }
}
