using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOModels;

namespace BLL.Logic
{
    public class OrderSummarizer
    {
        public static OrderLineDTO OrderlineSum(OrderLineDTO orderline, IEnumerable<ProductDTO> allProduct)
        {
            if (orderline == null) throw new ArgumentNullException("orderline");
            if (allProduct == null) throw new ArgumentNullException("allProduct");
            var product = allProduct.FirstOrDefault(x => x.id == orderline.ProductId);
            if (product == null) throw new Exception("product id doesn't exist");
   
            orderline.LineTotal = orderline.Amount*product.salesPrice;
            return orderline;
        }

        public static OrderDTO OrderSum(OrderDTO order, IEnumerable<OrderLineDTO> allOrderline, IEnumerable<ProductDTO> allProduct)
        {
            order.SumPurchase = 0;
            if (order == null) throw new ArgumentNullException("order");
            if (allOrderline == null) throw new ArgumentNullException("allOrderline");
            if (allProduct == null) throw new ArgumentNullException("allProduct");

            var orderlines = allOrderline.Where(x => x.OrderId == order.id).Select(_orderlines => OrderlineSum(_orderlines, allProduct));
            if (orderlines == null) throw new Exception("This order doesn't have any orderlines.");

            foreach (var item in orderlines)
                order.SumPurchase += item.LineTotal;
            order.sumShipping = order.SumPurchase + order.Shipping;
            return order;
        }
    }
}
