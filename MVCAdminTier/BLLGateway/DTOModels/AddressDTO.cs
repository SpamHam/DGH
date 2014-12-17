using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLGateway.DTOModels
{
    public class AddressDTO : IGenericDTO
    {
        [Required(ErrorMessage = "Name Required")]

        public int id { get; set; }
        [Display(Name = "Street name")]
        public string streetName { get; set; }
        [Display(Name = "Street number")]
        public string streetNumber { get; set; }
        public int cityId { get; set; }
    }
}
