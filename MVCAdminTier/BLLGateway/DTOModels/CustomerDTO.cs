namespace BLLGateway.DTOModels
{
    public class CustomerDTO : IGenericDTO
    {
        public int id { get; set; }
        public string phone { get; set; }
        public int? deliveryAddressId { get; set; }
        public int invoiceAddressId { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
