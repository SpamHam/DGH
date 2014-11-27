using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTOModels;


namespace DAL.Repository.Impl
{
    internal class OrderLineRepository : GenericRepository<OrderLineDTO>
    {
        public override OrderLineDTO Get(DGHEntities db, int Id)
        {
            return db.OrderLines.Select(toOrderLineDTO).FirstOrDefault(x => x.id == Id);
        }

        public override IEnumerable<OrderLineDTO> GetAll(DGHEntities db)
        {
            return db.OrderLines.ToList().Select(toOrderLineDTO).ToList();
        }

        public override void Add(DGHEntities db, OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null) throw new ArgumentNullException("orderLineDTO");
            db.OrderLines.Add(ToOrderLine(orderLineDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null) throw new ArgumentNullException("orderLineDTO");
            db.Entry(ToOrderLine(orderLineDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int Id)
        {
            db.OrderLines.Remove(db.OrderLines.FirstOrDefault(x => x.id == Id));
            db.SaveChanges();
        }

        private OrderLine ToOrderLine(OrderLineDTO orderLineDTO)
        {
            var orderLine = new OrderLine()
            {
                orderId = orderLineDTO.OrderId,
                productId = orderLineDTO.ProductId,
                lineTotal = orderLineDTO.LineTotal,
                amount = orderLineDTO.Amount,
        };
            return orderLine;
        }

        private OrderLineDTO toOrderLineDTO(OrderLine orderLine)
        {
            var orderLineDTO = new OrderLineDTO()
            {
                OrderId = orderLine.orderId,
                ProductId = orderLine.productId,
                LineTotal = orderLine.lineTotal,
                Amount = orderLine.amount,
            };
            return orderLineDTO;
        }
    }
}
