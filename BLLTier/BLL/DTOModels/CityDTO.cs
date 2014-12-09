using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class CityDTO : IGenericDTO
    {
        public int id { get; set; }
        public string zipCode { get; set; }
        public string City { get; set; }

    }
}
