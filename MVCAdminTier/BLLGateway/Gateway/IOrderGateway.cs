using System;
using System.Collections.Generic;
using BLLGateway.DTOModels;

namespace BLLGateway.Gateway
{
    public interface IOrderGateway : IGenericGateway<OrderDTO>
    {
        IEnumerable<OrderModelDTO> GetAllModels(String path);
    }
}
