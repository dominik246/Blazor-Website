using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AlgorithmLibrary.Extensions
{
    public static class StringToSafeUrl
    {
        public static string ToSafeUrl(this string value)
        {

            //First to lower case 
            value = value.ToLowerInvariant();

            //Remove all accents
            //var bytes = Encoding.GetEncoding(28598).GetBytes(value);

            //value = Encoding.ASCII.GetString(bytes);

            //Replace spaces 
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars 
            value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

            //Trim dashes from end 
            value = value.Trim('-', '_');

            //Replace double occurences of - or \_ 
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }
    }
}
