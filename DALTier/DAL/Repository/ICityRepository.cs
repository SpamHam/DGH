using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface ICityRepository : IGenericRepository<CityDTO>
    {
        CityDTO getCityByZipcode(string zipcode);
    }
}
