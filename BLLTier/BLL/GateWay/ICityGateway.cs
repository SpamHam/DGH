using BLL.DTOModels;
using BLL.Gateway;
using System;

namespace BLL.GateWay
{
    public interface ICityGateway : IGenericGateway<CityDTO>
    {
        /// <summary>
        /// gets a <"City"> by giving a <"zipcode"> to a specific Url <"path">.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="zipcode"></param>
        /// <returns></returns>
        CityDTO getCityByZipcode(String path, String zipcode);
    }
}
