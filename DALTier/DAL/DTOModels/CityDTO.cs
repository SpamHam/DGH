using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOModels
{
    public class CityDTO :IGenericDTO
    {
        public string zipCode { get; set; }
        public string City { get; set; }
        public int id { get; set; }
        }
    }
