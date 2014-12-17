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
        /// <summary>
        /// gets a <"City"> by giving a <"zipcode"> to a specific Url <"path">.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        CityDTO getCityByZipcode(String Path, String zipcode);
    }
}
