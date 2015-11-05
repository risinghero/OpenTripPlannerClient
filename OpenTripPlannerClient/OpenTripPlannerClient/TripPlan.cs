using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// Trip plan
    /// </summary>
    /// <seealso cref="http://dev.opentripplanner.org/apidoc/0.15.0/ns0_tripPlan.html"/>
    public class TripPlan
    {
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Date { get; set; }

        public Place From { get; set; }

        public Place To { get; set; }

        public Itinerary[] Itineraries { get; set; }
    }
}
