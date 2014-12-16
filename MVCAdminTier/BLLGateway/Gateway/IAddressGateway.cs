using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLGateway.Gateway
{
   public interface IAddressGateway : IGenericGateway<AddressDTO>
    {
        AddressDTO getLatestAddress(String path);
    }
}
