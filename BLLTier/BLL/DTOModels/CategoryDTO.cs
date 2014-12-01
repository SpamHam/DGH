using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class CategoryDTO : IGenericDTO
    {
        public int id { get; set; }
        public string categoryName { get; set; }
    }
}
