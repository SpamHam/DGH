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
        private decimal EuroInDKK;
        string path = "http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da";

        public decimal EuroToDKK(){
            
            XmlDocument theDocument = new XmlDocument();
            theDocument.Load(path);
            XmlNode node = theDocument.SelectSingleNode("//currency[@code='EUR']");  
        return EuroInDKK = Convert.ToDecimal(node.Attributes["rate"].Value) / 100;}
    }       
    }
