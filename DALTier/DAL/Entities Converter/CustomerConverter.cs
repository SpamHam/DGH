using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTOModels;

namespace DAL.Entities_Converter
{
    class CustomerConverter
    {
        public static Customer ToCustomer(CustomerDTO DTO)
        {
            var customer = new Customer()
            {
                id = DTO.id,
                phone = DTO.phone,
                deliveryAddressId = DTO.deliveryAddressId,
                invoiceAddressId = DTO.invoiceAddressId,
                email = DTO.email,
                firstName = DTO.firstName,
                lastName = DTO.lastName
            };
            return customer;
        }
        public static CustomerDTO ToCustomerDTO(Customer Entity)
        {
            var customerDTO = new CustomerDTO()
            {
                id = Entity.id,
                phone = Entity.phone,
                deliveryAddressId = Entity.deliveryAddressId,
                invoiceAddressId = Entity.invoiceAddressId,
                email = Entity.email,
                firstName = Entity.firstName,
                lastName = Entity.lastName
            };
            return customerDTO;
        }
    }
}
