using System.Collections.Generic;

namespace DAL.Repository
{
  public interface IGenericRepository<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Create(T type);

        void Update(T type);

        void Delete(int id);
    }
}
