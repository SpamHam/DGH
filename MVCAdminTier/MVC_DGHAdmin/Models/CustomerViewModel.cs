using BLLGateway.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DGHAdmin.Models
{
    public class CustomerViewModel
    {
        public List<CustomerDTO> Customer { set; get; }

        public CustomerDTO SelectedCustomer { set; get; }
    }
}