using System.ComponentModel.DataAnnotations;
namespace BLLGateway.DTOModels
{
    public class CustomerDTO : IGenericDTO
    {
        [Required(ErrorMessage = "Name Required")]
        public int id { get; set; }
        public string phone { get; set; }
        public int? deliveryAddressId { get; set; }
        public int invoiceAddressId { get; set; }
        public string email { get; set; }
        [Display(Name = "First name")]
        public string firstName { get; set; }
        [Display(Name = "Last name")]
        public string lastName { get; set; }
    }
}
