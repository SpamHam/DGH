using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTOModels;
using DAL.Entities_Converter;
using System.Data.Entity;

namespace DAL.Repository.Impl
{
    internal class CustomerRepository : GenericRepository<CustomerDTO>
    {
        public override CustomerDTO Get(DGHEntities db, int id)
        {
            return db.Customers.Select(CustomerConverter.ToCustomerDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<CustomerDTO> GetAll(DGHEntities db)
        {
            return db.Customers.Select(CustomerConverter.ToCustomerDTO).ToList();
        }

        public override void Add(DGHEntities db, CustomerDTO customerDTO)
        {
            if (customerDTO == null) throw new ArgumentNullException("customerDTO");
            db.Customers.Add(CustomerConverter.ToCustomer(customerDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, CustomerDTO customerDTO)
        {
            if (customerDTO == null) throw new ArgumentNullException("customerDTO");
            db.Entry(CustomerConverter.ToCustomer(customerDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Customers.Remove(db.Customers.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
