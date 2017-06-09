using System;
using System.Collections.Generic;
using System.Text;

namespace Shortener.Web.Helper
{
    public static class ShortUrlHelper
    {
        private static List<char> _letters;

        static ShortUrlHelper()
        {
            FillLetters();
        }

        private static void FillLetters()
        {
            _letters = new List<char>();
            for (char c = 'A'; c <= 'Z'; ++c)
            {
                _letters.Add(c);
            }

            for (char c = 'a'; c <= 'z'; ++c)
            {
                _letters.Add(c);
            }
        }

        public static string GenerateUrl()
        {
            var rnd = new Random();

            var builder = new StringBuilder();

            builder.Append(rnd.Next(0, 98));
            builder.Append(_letters[rnd.Next(0, 51)]);
            builder.Append(_letters[rnd.Next(0, 51)]);
            builder.Append(rnd.Next(0, 98));
            builder.Append(_letters[rnd.Next(0, 51)]);
            builder.Append(_letters[rnd.Next(0, 51)]);
            builder.Append(rnd.Next(0, 98));
            builder.Append(_letters[rnd.Next(0, 51)]);
            builder.Append(_letters[rnd.Next(0, 51)]);
            builder.Append(DateTime.UtcNow.Year.ToString().Substring(2, 2));

            return builder.ToString();
        }
    }
}