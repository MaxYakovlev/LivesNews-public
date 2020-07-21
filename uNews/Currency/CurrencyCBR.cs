using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using uNews.Models;

namespace uNews.Currency
{
    public class CurrencyCBR
    {
        private readonly string url = "https://www.cbr-xml-daily.ru/daily_utf8.xml";

        public async Task<List<CurrencyItem>> GetCurrenciesAsync()
        {
            List<CurrencyItem> currencies = new List<CurrencyItem>();

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(result);

            XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("Valute");

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                CurrencyItem currencyItem = new CurrencyItem();

                foreach (XmlNode childXmlNode in xmlNode.ChildNodes)
                {
                    switch (childXmlNode.Name)
                    {
                        case "CharCode": currencyItem.CharCode = childXmlNode.InnerText; break;
                        case "Nominal": currencyItem.Nominal = childXmlNode.InnerText; break;
                        case "Name": currencyItem.Name = childXmlNode.InnerText; break;
                        case "Value": currencyItem.Value = childXmlNode.InnerText; break;
                    }
                }

                currencies.Add(currencyItem);
            }

            return currencies;
        }
    }
}
