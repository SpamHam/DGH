using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Impl
{
   internal class AddressRepository : IGenericRepository<AddressDTO>
    {
        public AddressDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(AddressDTO type)
        {
            throw new NotImplementedException();
        }

        public void Update(AddressDTO type)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
