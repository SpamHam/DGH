using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities_Converter
{
   public class AddressConverter
    {
        public static Address ToAddress(AddressDTO addressDTO)
        {
            var address = new Address()
            {
                id = addressDTO.id,
                streetName = addressDTO.streetName,
                streetNumber = addressDTO.streetNumber

            };
            return address;
        }
        public static AddressDTO ToAddressDTO(Address address)
        {
            var addressDTO = new AddressDTO()
            {
                id = address.id,
                streetName = address.streetName,
                streetNumber = address.streetNumber
            };

            return addressDTO;
        }
    }
}
