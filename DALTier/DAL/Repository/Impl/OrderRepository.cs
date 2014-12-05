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
                IEnumerable<OrderModelDTO> orderModel = db.Orders.Select(order => ToOrderView(order, db)).ToList();
                return orderModel;

            }
        }
        public OrderModelDTO ToOrderView(Order order, DGHEntities db)
        {
            var orderModelDto = new OrderModelDTO()
            {
                OrderLine = db.OrderLines.Where(i => i.orderId == order.id).Select(OrderLineConverter.ToOrderlineView).ToList(),
                CustomerName = order.Customer.firstName + " " + order.Customer.lastName,
                id = order.id,
                OrderDate = order.orderDate,
                SumPurchase = order.sumPurchase,
                Shipping = order.Shipping,
                sumShipping = order.sumShipping
            };
            if (order.shippedDate != null)
                orderModelDto.shippedDate = (DateTime)order.shippedDate;
            return orderModelDto;
        }
    }
}
