using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTOModels;


namespace DAL.Repository.Impl
{
    internal class OrderLineRepository : GenericRepository<OrderLineDTO>
    {
        public override OrderLineDTO Get(DGHEntities db, int id)
        {
            return db.OrderLines.Select(OrderLineConverter.toOrderLineDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<OrderLineDTO> GetAll(DGHEntities db)
        {
            return db.OrderLines.ToList().Select(OrderLineConverter.toOrderLineDTO).ToList();
        }

        public override void Add(DGHEntities db, OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null) throw new ArgumentNullException("orderLineDTO");
            db.OrderLines.Add(OrderLineConverter.ToOrderLine(orderLineDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null) throw new ArgumentNullException("orderLineDTO");
            db.Entry(OrderLineConverter.ToOrderLine(orderLineDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.OrderLines.Remove(db.OrderLines.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
