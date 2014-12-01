using DAL.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities_Converter;
using System.Data.Entity;

namespace DAL.Repository.Impl
{
    internal class CategoryRepository: GenericRepository<CategoryDTO>
    {


        public override CategoryDTO Get(DGHEntities db, int id)
        {
            return db.Categories.Select(CategoryConverter.ToCategoryDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<CategoryDTO> GetAll(DGHEntities db)
        {
            return db.Categories.Select(CategoryConverter.ToCategoryDTO).ToList();
        }

        public override void Add(DGHEntities db, CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) throw new ArgumentNullException("categoryDTO");
            db.Categories.Add(CategoryConverter.ToCategory(categoryDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, CategoryDTO categoryDTO)
        {
            if (categoryDTO == null) throw new ArgumentNullException("categoryDTO");
            db.Entry(CategoryConverter.ToCategory(categoryDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Categories.Remove(db.Categories.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
