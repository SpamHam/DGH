using System.Collections.Generic;
using System.Net.Http;
using BLLGateway.DTOModels;

namespace BLLGateway.Gateway.Gateways
{
    class OrderGateway : GenericGateway<OrderDTO>, IOrderGateway
    {

        public IEnumerable<OrderModelDTO> GetAllModels(string path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<IEnumerable<OrderModelDTO>>().Result;
        }
    }
}
