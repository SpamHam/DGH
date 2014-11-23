using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOModels
{
 public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string productNumber { get; set; }
        public string color { get; set; }
        public int stock { get; set; }
        public decimal salesPrice { get; set; }
    }
}
