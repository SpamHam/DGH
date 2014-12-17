using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOModels;

namespace BLL.Logic
{
    public class OrderSummarizer
    {
        /// <summary>
        /// returns the <"orderline"> with a calculated linetotal, where it search the price in <"AllProduct"> and times that with the amount in <"Orderline">. 
        /// </summary>
        /// <param name="orderline"></param>
        /// <param name="allProduct"></param>
        /// <returns></returns>
        public static OrderLineDTO OrderlineSum(OrderLineDTO orderline, IEnumerable<ProductDTO> allProduct)
        {
            if (orderline == null) throw new ArgumentNullException("orderline");
            if (allProduct == null) throw new ArgumentNullException("allProduct");
            var product = allProduct.FirstOrDefault(x => x.id == orderline.ProductId);
            if (product == null) throw new Exception("product id doesn't exist");
   
            orderline.LineTotal = orderline.Amount*product.salesPrice;
            return orderline;
        }

        /// <summary>
        /// returns <"order"> with a calculated SumPurchase and SumShipping.
        /// it takes <"allOrderline"> and find those witch are connected to <"order"> and calculate those using <"orderlineSum">.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="allOrderline"></param>
        /// <param name="allProduct"></param>
        /// <returns></returns>
        public static OrderDTO OrderSum(OrderDTO order, IEnumerable<OrderLineDTO> allOrderline, IEnumerable<ProductDTO> allProduct)
        {
            if (order == null) throw new ArgumentNullException("order");
            if (allOrderline == null) throw new ArgumentNullException("allOrderline");
            if (allProduct == null) throw new ArgumentNullException("allProduct");

            order.SumPurchase = 0;

            var orderlines = allOrderline.ToList().Where(x => x.OrderId == order.id).Select(_orderlines => OrderlineSum(_orderlines, allProduct));
            if (!orderlines.Any()) throw new Exception("This order doesn't have any orderlines.");

            foreach (var item in orderlines)
                order.SumPurchase += item.LineTotal;
            order.sumShipping = order.SumPurchase + order.Shipping;
            return order;
        }
    }
}
