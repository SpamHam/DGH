﻿using System;
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
            return db.OrderLines.Select(OrderLineConverter.ToOrderLineDTO).FirstOrDefault(x => x.id == id);
        }

        public override IEnumerable<OrderLineDTO> GetAll(DGHEntities db)
        {
            return db.OrderLines.ToList().Select(OrderLineConverter.ToOrderLineDTO).ToList();
        }

        public override void Add(DGHEntities db, OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null) throw new ArgumentNullException("orderLineDTO");
            if (UpdateExisting(db, orderLineDTO)) return;
            db.OrderLines.Add(OrderLineConverter.ToOrderLine(orderLineDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, OrderLineDTO orderLineDTO)
        {
            if (orderLineDTO == null) throw new ArgumentNullException("orderLineDTO");
            if (UpdateExisting(db, orderLineDTO)) 
                db.OrderLines.Remove(db.OrderLines.FirstOrDefault(x => x.id == orderLineDTO.id));
            else
                db.Entry(OrderLineConverter.ToOrderLine(orderLineDTO)).State = EntityState.Modified;                
            db.SaveChanges();
        }

        public Boolean UpdateExisting(DGHEntities db, OrderLineDTO orderLineDTO)
        {
            var oldOrderline = db.OrderLines.Select(OrderLineConverter.ToOrderLineDTO).FirstOrDefault(x => x.OrderId == orderLineDTO.OrderId && x.ProductId == orderLineDTO.ProductId && x.id != orderLineDTO.id);
            if (oldOrderline == null) return false;
            oldOrderline.Amount = orderLineDTO.Amount + oldOrderline.Amount;
            oldOrderline.LineTotal = orderLineDTO.LineTotal + oldOrderline.LineTotal;

            db.Entry(OrderLineConverter.ToOrderLine(oldOrderline)).State = EntityState.Modified;
            return true;
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.OrderLines.Remove(db.OrderLines.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
