using System.Text.RegularExpressions;

namespace Mantasflowers.WebApi.Extensions
{
    public static class ResponseExtensions
    {
        private static string _pattern => @"([^()]*)";
        /// <summary>
        /// Returns substring within given two characters
        /// </summary>
        public static string SubstringWithin(this string str, char begin, char end)
        {
            Match result = Regex.Match(
                str,
                Regex.Escape(begin.ToString()) +
                _pattern +
                Regex.Escape(end.ToString())
                );

            if (result.Success)
            {
                return result.Groups[1].Value;
            }

            return str;
        }

        public static bool ContainsEnclosing(this string str, char begin, char end)
        {
            return Regex.IsMatch(
                str,
                Regex.Escape(begin.ToString()) +
                _pattern +
                Regex.Escape(end.ToString())
                );
        }
    }
}
