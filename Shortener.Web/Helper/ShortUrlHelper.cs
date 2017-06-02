using System;
using System.Collections.Generic;
using System.Text;

namespace Shortener.Web.Helper
{
    public static class ShortUrlHelper
    {
        private static List<Char> _letters;

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
        }

        public static string GenerateUrl()
        {
            var partOne = new Random();

            var builder = new StringBuilder();

            builder.Append(partOne.Next(0, 98));
            builder.Append(_letters[partOne.Next(0, 25)]);
            builder.Append(_letters[partOne.Next(0, 25)].ToString().ToLower());
            builder.Append(partOne.Next(0, 98));
            builder.Append(_letters[partOne.Next(0, 25)]);
            builder.Append(_letters[partOne.Next(0, 25)].ToString().ToLower());
            builder.Append(partOne.Next(0, 98));
            builder.Append(_letters[partOne.Next(0, 25)]);
            builder.Append(_letters[partOne.Next(0, 25)].ToString().ToLower());
            builder.Append(DateTime.UtcNow.Year.ToString().Substring(2, 2));

            return builder.ToString();
        }
    }
}