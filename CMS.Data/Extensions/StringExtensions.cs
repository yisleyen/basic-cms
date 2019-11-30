using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Data
{
    public static partial class Extensions
    {
        public static int GetWordCount(this string value)
        {
            return value.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string UppercaseFirstLetter(this string value)
        {
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return value;
        }

        public static string ToTitleCase(this string value)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            value = textInfo.ToTitleCase(value);
            return value;
        }

        public static string ReplaceTurkishCharacters(this string value)
        {
            value = value.Replace("ğ", "g")
                         .Replace("Ğ", "G")
                         .Replace("ş", "s")
                         .Replace("Ş", "S")
                         .Replace("ı", "i")
                         .Replace("İ", "I")
                         .Replace("ü", "u")
                         .Replace("Ü", "U")
                         .Replace("ö", "o")
                         .Replace("Ö", "O")
                         .Replace("ç", "c")
                         .Replace("Ç", "C");

            return value;
        }

        public static string ToUrlSlug(this string value)
        {
            //First to lower case
            value = value.ToLowerInvariant();

            //Remove all accents
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);

            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }

        public static string CleanInvalidXmlChars(this string value)
        {
            string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            return Regex.Replace(value, re, "");
        }

        public static string RemoveRepeatedWhiteSpace(this string value)
        {
            string[] tmp = value.ToString().Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string word in tmp)
            {
                string tmpw = word.Replace("\r", "");
                tmpw = tmpw.Replace("\n", "");
                tmpw = tmpw.Replace("\t", "");
                sb.Append(tmpw + " ");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
