using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Url_Shortener.Extensions {
    public class Helper {

        private static Random random = new Random();


        public static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomInt(int length) {
            const string numbs = "1234567890";
            return new string(Enumerable.Repeat(numbs, length).Select(s => s[random.Next(s.Length)]).ToArray());

        }

        public static string FormatUrl(string Url, bool IncludeHttp = false) {

            Url = Url.ToLower();

            switch (IncludeHttp) {
                case true:
                    if (!(Url.StartsWith("http://") || Url.StartsWith("https://")))
                        Url = "http://" + Url;
                    break;
                case false:
                    if (Url.StartsWith("http://"))
                        Url = Url.Remove(0, "http://".Length);
                    if (Url.StartsWith("https://"))
                        Url = Url.Remove(0, "https://".Length);
                    break;
            }

            return Url;

        }


        public static string ReplaceAllSpaces(string str) {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            var replace = rgx.Replace(str, "");
            return replace.Replace(" ", "-");
        }

        public static string Truncate(string str, int maxLength, string suffix) {
            if (str.Length > maxLength) {
                var words = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var sb = new StringBuilder();
                for (int i = 0; sb.ToString().Length + words[i].Length <= maxLength; i++) {
                    sb.Append(words[i]);
                    sb.Append(" ");
                }
                str = sb.ToString().TrimEnd(' ') + suffix;
            }
            return str.Trim();
        }
        public static int HowManyDaysAgo(DateTime date) {
            int dateCalc = (date - DateTime.Now).Days;
            var result = Math.Abs(dateCalc);

            return result;
        }
    }

}
