using System.Collections.Generic;
using uNews.Models;

namespace uNews.ViewModels
{
    public class NewsCurrenciesViewModel
    {
        public List<News> News { get; set; }

        public List<CurrencyItem> CurrencyItems { get; set; }

        public List<CurrencyItem> TopCurrencies { get; set; }
    }
}
