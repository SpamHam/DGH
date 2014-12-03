using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL.Logic
{
    class CurrencyConverter
    {
        private static string path = "http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da";

        public static decimal FromDKToEuro(decimal theValue)
        {

            XmlDocument theDocument = new XmlDocument();
            theDocument.Load(path);
            XmlNode node = theDocument.SelectSingleNode("//currency[@code='EUR']");
            decimal EuroInDKK = Convert.ToDecimal(node.Attributes["rate"].Value) / 100;
            return (decimal.Round((theValue / EuroInDKK), 2));
        }
    }
}
