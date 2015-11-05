using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// A list of coordinates encoded as a string. See Encoded polyline algorithm format
    /// </summary>
    /// <seealso cref="http://dev.opentripplanner.org/apidoc/0.15.0/ns0_encodedPolylineBean.html"/>
    public class EncodedPolylineBean
    {
        /// <summary>
        /// The encoded points of the polyline. 
        /// </summary>
        [JsonProperty("points")]
        public String PointsEncoded { get; set; }

        /// <summary>
        /// Levels describes which points should be shown at various zoom levels. Presently, we show all points at all zoom levels. 
        /// </summary>
        public String Levels { get; set; }

        /// <summary>
        /// The number of points in the string 
        /// </summary>
        public int Length { get; set; }

        public IEnumerable<GeoCoordinate> GetPoints()
        {
            return EncodedPolylineAlgorithm.Decode(PointsEncoded);
        }
    }
}
