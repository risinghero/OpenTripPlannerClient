using System;

namespace Anothar.OpenTripPlannerClient
{
    static class Url
    {
        public static String Combine(String baseUrl,String relativeUrl)
        {
            var baseUri = new Uri(baseUrl);
            var relativeUri = new Uri(relativeUrl, UriKind.Relative);
            var fullUri = new Uri(baseUri, relativeUri);
            return fullUri.ToString();
        }
    }
}
