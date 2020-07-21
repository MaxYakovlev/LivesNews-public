using System.Collections.Generic;
using uNews.Models;

namespace uNews.ViewModels
{
    public class OneNewsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Date { get; set; }

        public string ImageLink { get; set; }

        public string Link { get; set; }

        public List<HtmlElement> HtmlElements { get; set; }
    }
}
