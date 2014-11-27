using DAL.DTOModels;
using System.Collections.Generic;

namespace DAL.Repository.Impl
{
    internal abstract class GenericRepository<T> :IGenericRepository<T> where T : GenericDTO
    {
        
        public T Get(int id)
        {
            using (var db = new DGHEntities())
            {
                return Get(db, id);
            }
        }

        public abstract T Get(DGHEntities db, int id);
        public IEnumerable<T> GetAll()
        {
            using (var db = new DGHEntities())
            {
                return GetAll(db);
            }
        }
        public abstract IEnumerable<T> GetAll(DGHEntities db);
        

        public void Create(T type)
        {
            using (var db = new DGHEntities())
            {
                Add(db, type);
            }
        }
        public abstract void Add(DGHEntities db, T type);

        public void Update(T type)
        {
            using (var db = new DGHEntities())
            {
                Update(db, type);
            }
        }
        public abstract void Update(DGHEntities db, T type);

        public void Delete(int id)
        {
            using (var db = new DGHEntities())
            {
                Delete(db, id);
            }
        }
        public abstract void Delete(DGHEntities db, int id);
        
    }
}
