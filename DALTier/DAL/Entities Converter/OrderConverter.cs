using System;
using DAL.DTOModels;

namespace DAL.Entities_Converter
{
    class OrderConverter
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
            };
            if (order.shippedDate == null) return orderDTO;
            orderDTO.shippedDate = (DateTime)order.shippedDate;
            orderDTO.Shipping = (int) order.Shipping;
            orderDTO.sumShipping = (int) order.sumShipping;
            return orderDTO;
        }
    }
}
