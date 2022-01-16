using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Upplysning
{
    internal static class UpplysningUrlHelper
    {
        public static string GetSearchUrl(string who, string where = null) => 
            string.IsNullOrWhiteSpace(where) ? $"https://www.upplysning.se/person/?x={GenerateToken()}&who={_urlEncode(who)}&m=1" : 
            $"https://www.upplysning.se/person/?x={GenerateToken()}&who={_urlEncode(who)}&where={_urlEncode(where)}&m=1";

        private static string _urlEncode(string term) => HttpUtility.UrlEncode(term.ToLower(), Encoding.GetEncoding("ISO-8859-1"));

        public static int GenerateToken()
        {
            return new Random().Next(1000, 9999);
        }
    }
}
