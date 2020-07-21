using System.Text.RegularExpressions;

namespace uNews.Validation
{
    public class ValidationService
    {
        public bool IsEmailValid(string email)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                return true;

            return false;
        }

        public bool IsPasswordValid(string email)
        {
            string pattern = "[а-яА-Я]";

            if (!Regex.IsMatch(email, pattern, RegexOptions.Compiled))
                return true;

            return false;
        }
    }
}
