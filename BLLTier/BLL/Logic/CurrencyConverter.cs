using System;
using System.Net;
using System.Xml;

namespace BLL.Logic
{
  
    public class CurrencyConverter
    {
        private static string path = "http://www.nationalbanken.dk/_vti_bin/DN/DataService.svc/CurrencyRatesXML?lang=da";
        private static bool pageExists;
  /// <summary>
  ///  reads and converts a value into a specific currency using an xml file 
  /// </summary>
  /// <param name="theValue"></param>
  /// <param name="xmlPath"></param>
  /// <returns></returns>
        public static decimal FromDKToEuro(decimal theValue, string xmlPath = null)
        {
            try
            {
                XmlDocument theDocument = new XmlDocument();
                theDocument.Load(xmlPath ?? path);
                XmlNode node = theDocument.SelectSingleNode("//currency[@code='EUR']");
                decimal EuroInDKK = Convert.ToDecimal(node.Attributes["rate"].Value) / 100;
                return (decimal.Round((theValue / EuroInDKK), 2));
            }
            catch (Exception ex)
            {
                if (ex is WebException)
                {
                    throw new Exception("The internet service is down at the moment");
                }
                if (ex is XmlException)
                {
                    throw new Exception("Xml parse failed");
                }
                else throw new Exception("No such currency exists");
            }
        }

        public static bool isServiceUp(string path)
        {
            try
            {
                pageExists = false;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.Method = WebRequestMethods.Http.Get;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return pageExists = response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                throw new Exception("The internet service is down at the moment");
            }
        }

        
    }
}
