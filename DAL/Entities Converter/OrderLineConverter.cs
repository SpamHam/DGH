using DAL.DTOModels;

namespace DAL
{
    class OrderLineConverter
    {
        public static OrderLine ToOrderLine(OrderLineDTO orderLineDTO)
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

        public static OrderLineDTO toOrderLineDTO(OrderLine orderLine)
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
