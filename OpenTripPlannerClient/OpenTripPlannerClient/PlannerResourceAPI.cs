using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// Trip planner
    /// </summary>
    /// <seealso cref="http://dev.opentripplanner.org/apidoc/0.15.0/resource_PlannerResource.html"/>
    public class PlannerResourceAPI
    {
        private readonly HttpClient _client;

        public PlannerResourceAPI(HttpClient client)
        {
            _client = client;
        }

        public async Task<PlanResponse> Plan(PlanRequest request)
        {
            var query = new Dictionary<string, string>
            {
                ["fromPlace"] =
                    $"{request.FromPlace.Latitude.ToString(CultureInfo.InvariantCulture)},{request.FromPlace.Longitude.ToString(CultureInfo.InvariantCulture)}",
                ["toPlace"] =
                    $"{request.ToPlace.Latitude.ToString(CultureInfo.InvariantCulture)},{request.ToPlace.Longitude.ToString(CultureInfo.InvariantCulture)}",
                ["date"] = request.Time.ToString("MM-dd-yyyy"),
                ["time"] = request.Time.ToString("HH:mm"),
                ["mode"] = request.Mode
            };
            using (
                var stream = await _client.GetStreamAsync(Url.AddQuery("routers/" + request.RouterId + "/plan", query)))
               return stream.Deserialize<PlanResponse>();
        }
    }

}
