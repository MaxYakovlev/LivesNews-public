using System.Collections.Generic;
using System.Threading.Tasks;
using uNews.Models;
using System.Xml;
using System.Net.Http;
using uNews.Exstensions;

namespace uNews.RSS
{
    sealed public class VedomostiRss
    {
        private readonly static string baseUrl = "https://www.vedomosti.ru/rss";

        public async Task<List<News>> GetNewsAsync(string path)
        {
            List<News> newsList = new List<News>();

            string url = baseUrl + path;

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(result);

            XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("item");

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                News news = new News();

                foreach (XmlNode childXmlNode in xmlNode.ChildNodes)
                {
                    switch (childXmlNode.Name)
                    {
                        case "title": news.Title = childXmlNode.InnerText; break;
                        case "link": news.Link = childXmlNode.InnerText; break;
                        case "author": news.Author = childXmlNode.InnerText; break;
                        case "enclosure": news.ImageLink = childXmlNode.Attributes.GetNamedItem("url").Value; break;
                        case "description": news.Description = childXmlNode.InnerText; break;
                        case "category": news.Category = childXmlNode.InnerText; break;
                        case "pubDate": news.PublicationDate = childXmlNode.InnerText.TranslateWeekday().TranslateMonth().Substring(0, childXmlNode.InnerText.LastIndexOf('+')); break;
                    }
                }

                if(!news.Link.Contains("test") && !news.Link.Contains("galleries"))
                    newsList.Add(news);
            }

            return newsList;
        }
    }
}
