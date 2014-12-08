using System;
using System.Collections.Generic;
using System.Net.Http;
using BLL.DTOModels;

namespace BLL.Gateway
{
    public interface IOrderGateway : IGenericGateway<OrderDTO>
    {
        IEnumerable<OrderModelDTO> GetAllModels(String path);
    }
}
