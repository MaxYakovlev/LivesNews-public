using System;
using System.Text;

namespace uNews.Security
{
    public static class Cryptography
    {
        private readonly static string Key = "!@#my$%^secret*&/key?`~3";

        public static string EncryptPassword(string password)
        {
            string result = password + Key;

            byte[] passwordBytes = Encoding.UTF8.GetBytes(result);

            return Convert.ToBase64String(passwordBytes);
        }
    }
}
