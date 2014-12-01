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
    internal class CategoryRepository: IGenericRepository<CategoryDTO>
    {

        public CategoryDTO Get(DGHEntities db, int id)
        {
            return db.Categories.Select(CategoryConverter.ToCategoryDTO).FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<CategoryDTO> GetAll(DGHEntities db)
        {
            return db.Categories.Select(CategoryConverter.ToCategoryDTO).ToList();
        }

        public void Create(CategoryDTO categoryDTO, DGHEntities db)
        {
            if (categoryDTO == null) throw new ArgumentNullException("categoryDTO");
            db.Categories.Add(CategoryConverter.ToCategory(categoryDTO));
            db.SaveChanges();
        }

        public void Update(CategoryDTO categoryDTO, DGHEntities db)
        {
            if (categoryDTO == null) throw new ArgumentNullException("categoryDTO");
            db.Entry(CategoryConverter.ToCategory(categoryDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id, DGHEntities db)
        {
            
        }
    }
}
