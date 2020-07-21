using AngleSharp;
using AngleSharp.Dom;
using AutoMapper;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using uNews.Models;
using uNews.ViewModels;

namespace uNews.Parsing
{
    sealed public class VedomostiParsing
    {
        public async Task<OneNewsViewModel> GetOneNews(OneNews oneNews, IMapper mapper)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(oneNews.Url);

            string source = await httpResponseMessage.Content.ReadAsStringAsync();

            IConfiguration config = Configuration.Default;

            IBrowsingContext context = BrowsingContext.New(config);

            IDocument document = await context.OpenAsync(req => req.Content(source));

            IElement[] textItems = document.All.Where(m => (m.LocalName == "p" && m.ClassList.Contains("box-paragraph__text"))
            || (m.LocalName == "h2" && m.ClassList.Contains("box-paragraph__subtitle"))
            || (m.LocalName == "b" && m.ClassList.Contains("box-paragraph__text"))).ToArray();

            OneNewsViewModel oneNewsViewModel = mapper.Map<OneNewsViewModel>(oneNews);

            foreach (IElement item in textItems)
            {
                HtmlElement htmlElement = new HtmlElement() { Name = item.LocalName, Text = item.Text() };

                oneNewsViewModel.HtmlElements.Add(htmlElement);
            }

            return oneNewsViewModel;
        }
    }
}
