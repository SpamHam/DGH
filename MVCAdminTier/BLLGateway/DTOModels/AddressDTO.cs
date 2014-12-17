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
        public int id { get; set; }
       [Display(Name = "Street name")]
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public int cityId { get; set; }
    }
}
