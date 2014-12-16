using System;
using System.Collections.Generic;
using System.Net.Http;
using BLL.DTOModels;
using BLL.Gateway;

namespace BLL.GateWay.Gateways
{
    class OrderGateway : GenericGateway<OrderDTO>, IOrderGateway
    {

        public IEnumerable<OrderModelDTO> GetAllModels(string path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<IEnumerable<OrderModelDTO>>().Result;
        }
    }
}
