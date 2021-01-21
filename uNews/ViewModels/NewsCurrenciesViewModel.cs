using System.Collections.Generic;
using uNews.Models;

namespace uNews.ViewModels
{
    public class NewsCurrenciesViewModel
    {
        public List<News> News { get; set; }

        public List<CurrencyItem> CurrencyItems { get; set; }

        public List<CurrencyItem> TopCurrencies { get; set; }

        public NewsCategoriesViewModel NewsCategoriesViewModel { get; set; }

        public NewsCurrenciesViewModel() => NewsCategoriesViewModel = new NewsCategoriesViewModel();
    }
}
