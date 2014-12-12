using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOModels;
using BLL.Logic;
using NUnit.Core;
using NUnit.Framework;

namespace Test_logic
{
    [TestFixture]
    internal class TestOrdersLogicLogic
    {
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Setup Called");

        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown Called");
        }

        [Test]
        public void orderTotal()
        {
            var orders = GetTestOrders().ToList();
            Assert.IsTrue(orders.Any());

            var ordertest1 = OrderSummarizer.OrderSum(orders.ElementAt(0), GetTestOrderLine(), GetTestProduct());
        
            Assert.AreEqual(ordertest1.id, 1);
            Assert.AreEqual(ordertest1.SumPurchase, 1302);
            Assert.AreEqual(ordertest1.sumShipping, 1332);

            Assert.Throws<ArgumentNullException>(() => OrderSummarizer.OrderSum(null, GetTestOrderLine(),GetTestProduct()));
            Assert.Throws<ArgumentNullException>(() => OrderSummarizer.OrderSum(orders.ElementAt(0), null,GetTestProduct()));
            Assert.Throws<ArgumentNullException>(() => OrderSummarizer.OrderSum(orders.ElementAt(0), GetTestOrderLine(),null));

            Assert.Throws<Exception>(() => OrderSummarizer.OrderSum(orders.ElementAt(2), GetTestOrderLine(), GetTestProduct()));

        }

        [Test]
        public void OrderlineTotal()
        {
            var orderlineTest1 = OrderSummarizer.OrderlineSum(GetTestOrderLine().ElementAt(0), GetTestProduct());
            Assert.AreEqual(orderlineTest1.LineTotal, 135);
            Assert.Throws<Exception>(() => OrderSummarizer.OrderlineSum(GetTestOrderLine().ElementAt(2), GetTestProduct()));

            Assert.Throws<ArgumentNullException>(() => OrderSummarizer.OrderlineSum(null, GetTestProduct()));

            Assert.Throws<ArgumentNullException>(() => OrderSummarizer.OrderlineSum(GetTestOrderLine().ElementAt(2), null));        
        }

        private IEnumerable<OrderDTO> GetTestOrders()
        {
            return new List<OrderDTO>
            {
                new OrderDTO()
                {
                 id = 1, CustomerId = 1, OrderDate = new DateTime(2012,11,12), shippedDate = new DateTime(2012,11,12),Shipping = 30, SumPurchase = 0, sumShipping = 0
                },
                new OrderDTO()
                {
                 id = 2, CustomerId = 2, OrderDate = new DateTime(2012,11,12), shippedDate = new DateTime(2012,11,12),Shipping = 22, SumPurchase = 0, sumShipping = 0
                },
                new OrderDTO()
                {
                 id = 3, CustomerId = 2, OrderDate = new DateTime(2012,11,12), shippedDate = new DateTime(2012,11,12),Shipping = 22, SumPurchase = 0, sumShipping = 0
                }
            };
        }

        private IEnumerable<OrderLineDTO> GetTestOrderLine()
        {
            return new List<OrderLineDTO>
            {
                new OrderLineDTO()
                {id = 1,OrderId = 2,ProductId = 1,Amount = 3,LineTotal = 0},
                new OrderLineDTO()
                {id = 2,OrderId = 2,ProductId = 4,Amount = 15,LineTotal = 0},
                new OrderLineDTO()
                {id = 3,OrderId = 2,ProductId = 3,Amount = 1,LineTotal = 0},
                new OrderLineDTO()
                {id = 4,OrderId = 1,ProductId = 1,Amount = 1,LineTotal = 0},
                new OrderLineDTO()
                {id = 5,OrderId = 1,ProductId = 2,Amount = 1,LineTotal = 0}, 
                new OrderLineDTO()
                {id = 6,OrderId = 1,ProductId = 4,Amount = 1,LineTotal = 0} 
            };
        }

        private IEnumerable<ProductDTO> GetTestProduct()
        {
            return new List<ProductDTO>
            {
                new ProductDTO()
                {
                    id = 1,active = true,categoryId = 1,color = "blue",imageUrl = null,name = "HorseGlue",productNumber = "123",salesPrice = 45,stock = 5
                },
                new ProductDTO()
                {
                    id = 2,active = true,categoryId = 2,color = "black",imageUrl = null,name = "Long Arrow",productNumber = "143",salesPrice = 12,stock = 12
                },
                new ProductDTO()
                {
                    id = 4,active = true,categoryId = 2,color = "blue",imageUrl = null,name = "Long Bow",productNumber = "139",salesPrice = 1245,stock = 3
                },
            };
        } 
    }
}