using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTOModels;


namespace DAL.Repository.Impl
{
    internal class OrderRepository : IOrderRepository
    {
        public OrderDTO Get(int id)
        {
            using (var db = new DGHEntities())
            {
                return db.Orders.Select(OrderConverter.toOrderDTO).FirstOrDefault(x => x.id == id);
            }
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            using (var db = new DGHEntities())
            {
                return db.Orders.Select(OrderConverter.toOrderDTO).ToList();
            }
        }

        public void Add(OrderDTO orderDTO)
        {
            using (var db = new DGHEntities())
            {
                if (orderDTO == null) throw new ArgumentNullException("orderDTO");
                db.Orders.Add(OrderConverter.ToOrder(orderDTO));
                db.SaveChanges();
            }
        }

        public void Update(OrderDTO orderDTO)
        {
            using (var db = new DGHEntities())
            {
                if (orderDTO == null) throw new ArgumentNullException("orderDTO");
                db.Entry(OrderConverter.ToOrder(orderDTO)).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new DGHEntities())
            {
                db.OrderLines.RemoveRange(db.OrderLines.AsEnumerable().Where(x => x.orderId == id));
                db.Orders.Remove(db.Orders.FirstOrDefault(x => x.id == id));
                db.SaveChanges();
            }
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
