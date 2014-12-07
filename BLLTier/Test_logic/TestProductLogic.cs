using BLL.DTOModels;
using BLL.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_logic
{
    [TestFixture]
    class TestProductLogic
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
        /// <summary>
        /// hej
        /// </summary>
        [Test]
        public void getActiveProductTest()
        {
            var p = ProductSorter.getActiveProducts(GetTestProducts());
            Assert.AreEqual(p.Count(), 2);
            foreach (var f in p)
            {
                Assert.IsTrue(f.active);
            }
        }

        private List<ProductDTO> GetTestProducts()
        {
            var testProducts = new List<ProductDTO>();
            testProducts.Add(new ProductDTO { id = 1, name = "Demo1", productNumber = "A1", active = true, categoryId = 1, color = "Blue", imageUrl = "", salesPrice = 120, stock = 40 });
            testProducts.Add(new ProductDTO { id = 2, name = "Demo2", productNumber = "A2", active = false, categoryId = 2, color = "Orange", imageUrl = "", salesPrice = 220, stock = 20 });
            testProducts.Add(new ProductDTO { id = 3, name = "Demo3", productNumber = "A3", active = true, categoryId = 3, color = "Yellow", imageUrl = "", salesPrice = 320, stock = 30 });
            testProducts.Add(new ProductDTO { id = 4, name = "Demo4", productNumber = "A4", active = false, categoryId = 4, color = "Black", imageUrl = "", salesPrice = 420, stock = 10 });

            return testProducts;
        }
    }
}
