namespace BLL.DTOModels
{
 public class ProductDTO: IGenericDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string productNumber { get; set; }
        public string color { get; set; }
        public int stock { get; set; }
        public decimal salesPrice { get; set; }
        public int categoryId { get; set;}
        public int? imageId { get; set; }

    }
}
