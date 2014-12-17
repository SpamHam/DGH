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
       /// <summary>
       /// finds a <"City"> in the database from the <"Zipcode"> entered.
       /// </summary>
       /// <param name="zipcode"></param>
       /// <returns></returns>
        CityDTO getCityByZipcode(string zipcode);
    }
}
