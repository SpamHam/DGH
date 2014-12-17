using System;
using System.Collections.Generic;
using System.Net.Http;
using BLL.DTOModels;

namespace BLL.Gateway
{
    public interface IOrderGateway : IGenericGateway<OrderDTO>
    {
        /// <summary>
        /// gets a <"OrderModelDTO"> from a specific Url <"path">.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IEnumerable<OrderModelDTO> GetAllModels(string path);
    }
}
