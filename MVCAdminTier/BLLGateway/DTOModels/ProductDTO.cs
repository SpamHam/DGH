using System.ComponentModel.DataAnnotations;
namespace BLLGateway.DTOModels
{
 public class ProductDTO: IGenericDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        [Display(Name = "product number")]
        public string productNumber { get; set; }
        public string color { get; set; }
        public int stock { get; set; }
     [Display(Name = "sales price")]
        public decimal salesPrice { get; set; }
        public int categoryId { get; set; }
     [Display(Name = "image url")]
        public string imageUrl { get; set; }
        public bool active { get; set; }

    }
}
