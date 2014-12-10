using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLGateway.Gateway
{
   public interface ICityGateway :IGenericGateway<CityDTO>
    {
        CityDTO getCityByZipcode(String Path, String zipcode);
    }
}
