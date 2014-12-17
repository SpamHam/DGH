using System.Collections.Generic;

namespace DAL.Repository
{
  public interface IGenericRepository<T>
    {
      /// <summary>
      /// Gets a <"T"> from the database.
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        T Get(int id);

      /// <summary>
      /// Gets all of <"T"> from the database.
      /// </summary>
      /// <returns></returns>
        IEnumerable<T> GetAll();

      /// <summary>
      /// Creates a <"T"> in the database.
      /// </summary>
      /// <param name="type"></param>
        void Create(T type);

      /// <summary>
      /// Updates a <"T"> in the database.
      /// </summary>
      /// <param name="type"></param>
        void Update(T type);

      /// <summary>
      /// Deletes a <"T"> from the database.
      /// </summary>
      /// <param name="id"></param>
        void Delete(int id);
    }
}
