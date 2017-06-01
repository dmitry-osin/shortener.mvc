using System;
using System.Collections.Generic;
using System.Text;

namespace Shortener.Web.Helper
{
    public class ShortUrlHelper
    {
        private static List<Char> Letters;

        static ShortUrlHelper()
        {
            FillLetters();
        }

        private static void FillLetters()
        {
            Letters = new List<char>();
            for (char c = 'A'; c <= 'Z'; ++c)
            {
                Letters.Add(c);
            }
        }

        public static string GenerateUrl()
        {
            var partOne = new Random();

            var builder = new StringBuilder();

            builder.Append(partOne.Next(0, 98));
            builder.Append(Letters[partOne.Next(0, 25)]);
            builder.Append(Letters[partOne.Next(0, 25)].ToString().ToLower());
            builder.Append(partOne.Next(0, 98));
            builder.Append(Letters[partOne.Next(0, 25)]);
            builder.Append(Letters[partOne.Next(0, 25)].ToString().ToLower());
            builder.Append(partOne.Next(0, 98));

            return builder.ToString();
        }
    }
}