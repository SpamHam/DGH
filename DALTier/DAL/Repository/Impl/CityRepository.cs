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
    internal class CityRepository : GenericRepository<CityDTO>, ICityRepository
    {
        
        public override CityDTO Get(DGHEntities db, int id)
        {
            return db.Cities.Select(CityConverter.toCityDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<CityDTO> GetAll(DGHEntities db)
        {
            return db.Cities.Select(CityConverter.toCityDTO).ToList();
        }

        public override void Update(DGHEntities db, CityDTO cityDTO)
        {
            if (cityDTO == null) throw new ArgumentNullException("cityDTO");
            db.Entry(CityConverter.toCity(cityDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Cities.Remove(db.Cities.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }

        public override void Add(DGHEntities db, CityDTO cityDTO)
        {
            if (cityDTO == null) throw new ArgumentNullException("cityDTO");
            db.Cities.Add(CityConverter.toCity(cityDTO));
            db.SaveChanges();
        }

        public CityDTO getCityByZipcode(string zipcode)
        {
            using (var db = new DGHEntities())
            {
                return db.Cities.Select(CityConverter.toCityDTO).FirstOrDefault(x => x.zipCode.Equals(zipcode));
            }
        }
    }
}
