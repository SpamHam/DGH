
namespace BLLGateway.DTOModels
{
    public class OrderLineDTO: IGenericDTO
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }

        public decimal LineTotal { get; set; }

        public int id { get; set; }
    }
}
