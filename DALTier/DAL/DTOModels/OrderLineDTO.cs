
namespace DAL.DTOModels
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
        public int id { get; set; }

        public string ProductName { get; set; }

        public string ProductPicture { get; set; }

        public decimal ProductPrice { get; set; }

        public int Amount { get; set; }

        public decimal LineTotal { get; set; }
    }
}
