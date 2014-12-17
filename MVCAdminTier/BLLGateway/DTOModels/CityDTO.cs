using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLGateway.DTOModels
{
    public class CityDTO : IGenericDTO
    {
        [Required(ErrorMessage = "name is required")]
        [Display(Name = "Zipcode")]
        public string zipCode { get; set; }
        public string City { get; set; }
        public int id { get; set; }
    }
}
