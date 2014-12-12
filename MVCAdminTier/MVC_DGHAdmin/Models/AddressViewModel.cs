using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLGateway.DTOModels;
namespace MVC_DGHAdmin.Models.Orders
{
    public class AddressViewModel
    {
        public List<CityDTO> City { get; set; }

        public CityDTO SelectedCity { get; set; }

        public List<AddressDTO> Address { get; set; }

        public AddressDTO SelectedAddress { get; set; }

        
    }
}