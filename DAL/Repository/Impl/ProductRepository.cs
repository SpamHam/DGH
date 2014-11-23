using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repository.Impl
{
    internal class ProductRepository : GenericRepository<Product>
    {
        public override Product Get(DGHEntities db, int id)
        {
            return db.Products.FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<Product> GetAll(DGHEntities db)
        {
            return db.Products.ToList();
        }

        public override void Add(DGHEntities db, Product type)
        {
            db.Products.Add(type);
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, Product type)
        {
            db.Entry(type).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Products.Remove(db.Products.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
