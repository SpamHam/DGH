using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
        public class AddressDTO : IGenericDTO
        {
            public int id { get; set; }
            public string streetName { get; set; }
            public string streetNumber { get; set; }
            public int cityId { get; set; }

        }
    }
