using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace BLL.GateWay.Gateways
{
    class AddressGateway : GenericGateway<AddressDTO>, IAddressGateway
    {
        
        public AddressDTO getLatestAddress(String path)
        {
            return GetClient().GetAsync(path).Result.Content.ReadAsAsync<AddressDTO>().Result;
        }
    }
}
