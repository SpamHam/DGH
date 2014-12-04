using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
  public interface IGenericRepository<T> where T : IGenericDTO
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Create(T type);

        void Update(T type);

        void Delete(int id);
    }
}
