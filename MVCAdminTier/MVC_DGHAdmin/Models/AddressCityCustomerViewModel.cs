using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DGHAdmin.Models
{
    public class AddressCityCustomerViewModel
    {
        public List<CityDTO> City { get; set; }

        public CityDTO SelectedCity { get; set; }

        public List<AddressDTO> Address { get; set; }

        public AddressDTO SelectedAddress { get; set; }

        public List<CustomerDTO> Customer { get; set; }

        public CustomerDTO SelectedCustomer { get; set; }
    }
}