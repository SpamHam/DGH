using System;
using System.Linq;
using DAL.DTOModels;

namespace DAL
{
    public class OrderConverter
    {
           public static Order ToOrder(OrderDTO orderDTO)
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

        public static OrderDTO toOrderDTO(Order order)
        {
            var orderDTO = new OrderDTO()
            {
                id = order.id,
                CustomerId = order.customerId,
                OrderDate = order.orderDate,
                SumPurchase = order.sumPurchase,
                Shipping = order.Shipping,
                sumShipping = order.sumShipping,
            };
            if (order.shippedDate == null) return orderDTO;
            orderDTO.shippedDate = (DateTime)order.shippedDate;
            return orderDTO;
        }

        public static OrderModelDTO ToOrderView(Order order, DGHEntities db)
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
