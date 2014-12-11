using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Logic;
using Test_logic;
using System.Xml;

namespace Test_logic
{
    [TestFixture]
    class TestXMLLogic
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
        public void testUrlServie()
        {
            Assert.IsTrue(CurrencyConverter.isServiceUp("http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da");
        }

        [Test]
        public void goodXML()
        {
           var result = CurrencyConverter.FromDKToEuro(744.01M, "C:\\Users\\Claus\\Source\\Repos\\DGH\\DGH\\BLLTier\\Test_logic\\xmlDummies\\Good XML.xml");
           Assert.AreEqual(100.0M, result);
        }

        [Test]
        public void badXML()
        {
            var ex = Assert.Catch<Exception>(() => CurrencyConverter.FromDKToEuro(744.01M, "C:\\Users\\Claus\\Source\\Repos\\DGH\\DGH\\BLLTier\\Test_logic\\xmlDummies\\Bad XML.xml"));
            StringAssert.Contains("No such currency exists", ex.Message);
        }

        [Test]
        public void serviceIsDown()
        {
            var ex = Assert.Catch<Exception>(() => CurrencyConverter.isServiceUp("http://www.naaationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da"));
            StringAssert.Contains("The internet service is down at the moment", ex.Message);
        }
    }
}
