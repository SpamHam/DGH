﻿using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLGateway.Gateway
{
   public interface IAddressGateway : IGenericGateway<AddressDTO>
    {
        /// <summary>
        /// Gets the last Created <"Address"> from a specific Url <"path">.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        AddressDTO getLatestAddress(String path);
    }
}
