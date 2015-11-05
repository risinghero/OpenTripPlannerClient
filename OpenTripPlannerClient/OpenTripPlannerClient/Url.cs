using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Anothar.OpenTripPlannerClient
{
    static class Url
    {
        /// <summary>
        /// Combine urls
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="relativeUrl"></param>
        /// <returns></returns>
        public static String Combine(String baseUrl,String relativeUrl)
        {
            var baseUri = new Uri(baseUrl);
            var relativeUri = new Uri(relativeUrl, UriKind.Relative);
            var fullUri = new Uri(baseUri, relativeUri);
            return fullUri.ToString();
        }

        /// <summary>
        /// Add parameters to query
        /// </summary>
        /// <param name="url">Root url</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public static String AddQuery(String url, Dictionary<string, string> parameters)
        {
            var result=new StringBuilder();
            result.Append(url);
            if (!url.EndsWith("?"))
                result.Append("?");
            var isFirst = true;
            foreach (var pair in parameters)
            {
                if (!isFirst)
                    result.Append("&");
                result.Append(WebUtility.UrlEncode(pair.Key));
                result.Append("=");
                result.Append(WebUtility.UrlEncode(pair.Value));
                isFirst = false;
            }
            return result.ToString();
        }
    }
}
