using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities_Converter
{
    class CityConverter
    {
        public static City toCity(CityDTO DTO)
        {
            var city = new City()
            {
                zipCode = DTO.zipCode,
                City1 = DTO.City
            };
            return city;
        }

        public static CityDTO toCityDTO(City Entity)
        {
            var cityDTO = new CityDTO()
            {
                zipCode = Entity.zipCode,
                City = Entity.City1
            };
            return cityDTO;
        }
    }
}
