﻿using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace BLLGateway.Gateway.Gateways
{
     class CityGateway : GenericGateway<CityDTO>, ICityGateway
    {

        public CityDTO getCityByZipcode(String path, String zipcode)
        {
            return GetClient().GetAsync(path + "/" + zipcode).Result.Content.ReadAsAsync<CityDTO>().Result;

            
        }

 
    }
}
