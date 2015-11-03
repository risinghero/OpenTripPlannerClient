using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Anothar.OpenTripPlannerClient
{
    public class OTPClient:IDisposable
    {
        private HttpClient _client;

        static OTPClient()
        {
            DefaultConnectionUrl = "http://localhost:8080/";
        }

        public OTPClient(String url)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Url.Combine(url,"/otp/"))
            };

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public OTPClient() : this(DefaultConnectionUrl) { }

        /// <summary>
        /// Default OTP Url
        /// </summary>
        /// <value>http://localhost:8080/</value>
        public static String DefaultConnectionUrl { get; set; }


        public RoutersAPI Routers { get { return new RoutersAPI(_client); } }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
