using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTOModels;


namespace DAL.Repository.Impl
{
    internal class OrderRepository :GenericRepository<OrderDTO>, IOrderRepository
    {
        public override OrderDTO Get(DGHEntities db, int id)
        {
           return db.Orders.Select(OrderConverter.toOrderDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<OrderDTO> GetAll(DGHEntities db)
        {
            return db.Orders.Select(OrderConverter.toOrderDTO).ToList();
        }

        public override void Add(DGHEntities db, OrderDTO orderDTO)
        {
                if (orderDTO == null) throw new ArgumentNullException("orderDTO");
                db.Orders.Add(OrderConverter.ToOrder(orderDTO));
                db.SaveChanges();
        }

        public override void Update(DGHEntities db, OrderDTO orderDTO)
        {
                if (orderDTO == null) throw new ArgumentNullException("orderDTO");
                db.Entry(OrderConverter.ToOrder(orderDTO)).State = EntityState.Modified;
                db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
                db.OrderLines.RemoveRange(db.OrderLines.AsEnumerable().Where(x => x.orderId == id));
                db.Orders.Remove(db.Orders.FirstOrDefault(x => x.id == id));
                db.SaveChanges();
        }

        public IEnumerable<OrderModelDTO> GetViewModel()
        {
            using (var db = new DGHEntities())
            {
               return db.Orders.Include("Customer").Include("OrderLines").Include("OrderLines.Product").ToList().Select(OrderConverter.ToOrderView);
            }
        }
    }
}
