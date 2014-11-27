using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTOModels;


namespace DAL.Repository.Impl
{
    internal class OrderRepository : GenericRepository<OrderDTO>
    {
        public override OrderDTO Get(DGHEntities db, int orderId)
        {
            return db.Orders.Select(toOrderDTO).FirstOrDefault(x => x.id == orderId);
        }

        public override IEnumerable<OrderDTO> GetAll(DGHEntities db)
        {
            return db.Orders.ToList().Select(toOrderDTO).ToList();
        }

        public override void Add(DGHEntities db, OrderDTO orderDTO)
        {
            if (orderDTO == null) throw new ArgumentNullException("orderDTO");
            db.Orders.Add(ToOrder(orderDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, OrderDTO orderDTO)
        {
            if (orderDTO == null) throw new ArgumentNullException("orderDTO");
            db.Entry(ToOrder(orderDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Orders.Remove(db.Orders.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }

        private Order ToOrder(OrderDTO orderDTO)
        {
            var order = new Order()
            {
                customerId = orderDTO.CustomerId,
                id = orderDTO.id,
                orderDate = orderDTO.OrderDate,
                sumPurchase = orderDTO.SumPurchase,
                shippedDate = orderDTO.shippedDate,
                Shipping = (int)orderDTO.Shipping,
                sumShipping = (int)orderDTO.sumShipping
        };
            return order;
        }

        private OrderDTO toOrderDTO(Order order)
        {
            var orderDTO = new OrderDTO()
            {
                id = order.id,
                CustomerId = order.customerId,
                OrderDate = order.orderDate,
                SumPurchase = order.sumPurchase,
            };
            if (order.shippedDate == null) return orderDTO;
            orderDTO.shippedDate = (DateTime)order.shippedDate;
            orderDTO.Shipping = (int) order.Shipping;
            orderDTO.sumShipping = (int) order.sumShipping;
            return orderDTO;
        }
    }
}
