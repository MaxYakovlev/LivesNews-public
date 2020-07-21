using System;

namespace uNews.Exstensions
{
    public static class TranslateWeekdayExstension
    {
        public static string TranslateWeekday(this string datetime)
        {
            if (datetime.Contains("Sun"))
            {
                datetime = datetime.Replace("Sun", "Вс");
                return datetime;
            }

            if (datetime.Contains("Mon"))
            {
                datetime = datetime.Replace("Mon", "Пн");
                return datetime;
            }

            if (datetime.Contains("Tue"))
            {
                datetime = datetime.Replace("Tue", "Вт");
                return datetime;
            }

            if (datetime.Contains("Wed"))
            {
                datetime = datetime.Replace("Wed", "Ср");
                return datetime;
            }

            if (datetime.Contains("Thu"))
            {
                datetime = datetime.Replace("Thu", "Чт");
                return datetime;
            }

            if (datetime.Contains("Fri"))
            {
                datetime = datetime.Replace("Fri", "Пят");
                return datetime;
            }

            if (datetime.Contains("Sat"))
            {
                datetime = datetime.Replace("Sat", "Сб");
                return datetime;
            }

            throw new Exception("The input string does not contain a suitable day of the week prefix");
        }
    }
}
