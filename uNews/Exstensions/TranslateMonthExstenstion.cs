using System;
using System.Linq.Expressions;

namespace uNews.Exstensions
{
    public static class TranslateMonthExstenstion
    {
        public static string TranslateMonth(this string datetime)
        {
            if (datetime.Contains("Jan"))
            {
                datetime = datetime.Replace("Jan", "Янв");
                return datetime;
            }

            if (datetime.Contains("Feb"))
            {
                datetime = datetime.Replace("Feb", "Фев");
                return datetime;
            }

            if (datetime.Contains("Mar"))
            {
                datetime = datetime.Replace("Mar", "Марта");
                return datetime;
            }

            if (datetime.Contains("Apr"))
            {
                datetime = datetime.Replace("Apr", "Апр");
                return datetime;
            }

            if (datetime.Contains("May"))
            {
                datetime = datetime.Replace("May", "Мая");
                return datetime;
            }

            if (datetime.Contains("Jun"))
            {
                datetime = datetime.Replace("Jun", "Июня");
                return datetime;
            }

            if (datetime.Contains("Jul"))
            {
                datetime = datetime.Replace("Jul", "Июля");
                return datetime;
            }

            if (datetime.Contains("Aug"))
            {
                datetime = datetime.Replace("Aug", "Авг");
                return datetime;
            }

            if (datetime.Contains("Sep"))
            {
                datetime = datetime.Replace("Sep", "Сен");
                return datetime;
            }

            if (datetime.Contains("Oct"))
            {
                datetime = datetime.Replace("Oct", "Окт");
                return datetime;
            }

            if (datetime.Contains("Nov"))
            {
                datetime = datetime.Replace("Nov", "Ноя");
                return datetime;
            }

            if (datetime.Contains("Dec"))
            {
                datetime = datetime.Replace("Dec", "Дек");
                return datetime;
            }

            throw new Exception("The input string does not contain the appropriate month year prefix");
        }
    }
}
