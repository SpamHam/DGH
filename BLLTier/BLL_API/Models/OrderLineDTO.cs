
namespace DAL.DTOModels
{
    public class OrderLineDTO: GenericDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }

        public decimal LineTotal { get; set; }

        public int id { get; set; }
    }
}
