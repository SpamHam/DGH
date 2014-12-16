using BLL.DTOModels;
using BLL.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GateWay
{
    public interface IAddressGateway : IGenericGateway<AddressDTO>
    {
        AddressDTO getLatestAddress(String path);
    }
}
