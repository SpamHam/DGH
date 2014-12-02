using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLGateway.DTOModels
{
    public class CategoryDTO: IGenericDTO
    {
        public int id { get; set; }
        public string categoryName { get; set; }
    }
}
