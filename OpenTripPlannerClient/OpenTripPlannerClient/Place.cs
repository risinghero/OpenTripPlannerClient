using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anothar.OpenTripPlannerClient
{
    public class Place
    {
        public Place()
        {
            _additionalData = new Dictionary<string, JToken>();
        }

        [JsonExtensionData]
        private readonly IDictionary<string, JToken> _additionalData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
           
            var longitude = (double)_additionalData["lon"];
            var latitude = (double)_additionalData["lat"];
            Coordinate=new GeoCoordinate(latitude,longitude);
        }


        public String Name { get; set; }

        public GeoCoordinate Coordinate { get; set; }

        public String VertexType { get; set; }
    }
}
