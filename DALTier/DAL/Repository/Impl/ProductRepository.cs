using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTOModels;
using DAL.Entities_Converter;


namespace DAL.Repository.Impl
{
    internal class ProductRepository : GenericRepository<ProductDTO>
    {
        public override ProductDTO Get(DGHEntities db, int id)
        {
            return db.Products.Select(ProductConverter.ToProductDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<ProductDTO> GetAll(DGHEntities db)
        {
            return db.Products.Select(ProductConverter.ToProductDTO).ToList();
        }

        public override void Add(DGHEntities db, ProductDTO productDTO)
        {
            if (productDTO == null) throw new ArgumentNullException("productDTO");
            db.Products.Add(ProductConverter.ToProduct(productDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, ProductDTO productDTO)
        {
            if (productDTO == null) throw new ArgumentNullException("productDTO");
            db.Entry(ProductConverter.ToProduct(productDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Products.Remove(db.Products.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
