using DAL.DTOModels;

namespace DAL
{
    public class OrderLineConverter
    {
        public static OrderLine ToOrderLine(OrderLineDTO orderLineDTO)
        {
            var orderLine = new OrderLine()
            {
                id = orderLineDTO.id,
                orderId = orderLineDTO.OrderId,
                productId = orderLineDTO.ProductId,
                lineTotal = orderLineDTO.LineTotal,
                amount = orderLineDTO.Amount,
            };
            return orderLine;
        }

        public static OrderLineDTO ToOrderLineDTO(OrderLine orderLine)
        {
            var orderLineDTO = new OrderLineDTO()
            {
                id = orderLine.id,
                OrderId = orderLine.orderId,
                ProductId = orderLine.productId,
                LineTotal = orderLine.lineTotal,
                Amount = orderLine.amount,
            };
            return orderLineDTO;
        }

        public static OrderLineModelDTO ToOrderlineView(OrderLine orderline)
        {
            return new OrderLineModelDTO()
            {
                Id = orderline.id,
                OrderId = orderline.orderId,
                ProductId = orderline.productId,
                ProductName = orderline.Product.name,
                ProductPicture = orderline.Product.imageUrl,
                ProductPrice = orderline.Product.salesPrice,
                Amount = orderline.amount,
                LineTotal = orderline.lineTotal,
            };
        }
    }
}
