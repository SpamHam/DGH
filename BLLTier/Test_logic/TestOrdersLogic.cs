using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTOModels;
using BLL.Logic;
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
        public void OrderlineTotal()
        {
            var OrderlineTest_1 = OrderSummarizer.OrderlineSum(GetTestOrderLine().First(), GetTestProduct());
            Assert.AreEqual(OrderlineTest_1.LineTotal, 135);

            Assert.Fail(OrderSummarizer.OrderlineSum(GetTestOrderLine().ElementAt(2), GetTestProduct()));
            Assert.Fail(OrderSummarizer.OrderlineSum(new OrderLineDTO(), GetTestProduct()));
            Assert.Fail(OrderSummarizer.OrderlineSum(GetTestOrderLine().ElementAt(2), new List<ProductDTO>()));

            var ordertest_1 = OrderSummarizer.OrderSum(GetTestOrders().ElementAt(1), GetTestOrderLine(), GetTestProduct());
            Assert.AreEqual(ordertest_1.SumPurchase, 1359);
            Assert.AreEqual(ordertest_1.sumShipping,1371);
        }

        private IEnumerable<OrderDTO> GetTestOrders()
        {
            var testOrders = new List<OrderDTO>
            {
                new OrderDTO()
                {
                 id = 1, CustomerId = 1, OrderDate = new DateTime(11-11-2011), shippedDate = new DateTime(11-12-2014),Shipping = 30, SumPurchase = 0, sumShipping = 0
                },
                new OrderDTO()
                {
                 id = 2, CustomerId = 2, OrderDate = new DateTime(11-11-2011), shippedDate = new DateTime(11-12-2014),Shipping = 22, SumPurchase = 0, sumShipping = 0
                },
            };
            return testOrders;
        }

        private IEnumerable<OrderLineDTO> GetTestOrderLine()
        {
            return new List<OrderLineDTO>
            {
                new OrderLineDTO()
                {id = 1,OrderId = 2,ProductId = 1,Amount = 3,LineTotal = 0},
                new OrderLineDTO()
                {id = 2,OrderId = 2,ProductId = 5,Amount = 15,LineTotal = 0},
                new OrderLineDTO()
                {id = 3,OrderId = 2,ProductId = 3,Amount = 1,LineTotal = 0},
                new OrderLineDTO()
                {id = 4,OrderId = 1,ProductId = 2,Amount = 2,LineTotal = 0}, // 24
                new OrderLineDTO()
                {id = 5,OrderId = 1,ProductId = 4,Amount = 1,LineTotal = 0}, // 1245 
                new OrderLineDTO()
                {id = 6,OrderId = 1,ProductId = 1,Amount = 2,LineTotal = 0} // 90
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