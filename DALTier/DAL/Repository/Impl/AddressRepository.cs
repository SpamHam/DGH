using DAL.DTOModels;
using DAL.Entities_Converter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Impl
{
   internal class AddressRepository : GenericRepository<AddressDTO>
    {

        public override AddressDTO Get(DGHEntities db, int id)
        {
          return db.Addresses.Select(AddressConverter.ToAddressDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<AddressDTO> GetAll(DGHEntities db)
        {
            return db.Addresses.Select(AddressConverter.ToAddressDTO).ToList();
        }

        public override void Add(DGHEntities db, AddressDTO type)
        {
            if (type == null) throw new ArgumentNullException("addressDTO");
            db.Addresses.Add(AddressConverter.ToAddress(type));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, AddressDTO type)
        {
            if (type == null) throw new ArgumentNullException("addressDTO");
            db.Entry(AddressConverter.ToAddress(type)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Categories.Remove(db.Categories.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
