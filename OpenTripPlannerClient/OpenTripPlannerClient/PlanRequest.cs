using System;

namespace Anothar.OpenTripPlannerClient
{
    public class PlanRequest
    {
        public PlanRequest()
        {
            RouterId = "default";
            Time = DateTime.Now;
        }

        /// <summary>
        /// The routerId selects between several graphs on the same server. 
        /// </summary>
        public String RouterId { get; set; }

        public GeoCoordinate FromPlace { get; set; }

        public GeoCoordinate ToPlace { get; set; }

        public DateTime Time { get; set; }

        public bool IsArriveBy { get; set; }

        public bool IsWheelChair { get; set; }

        public double? MaxWalkDistance { get; set; }

        public String Mode { get; set; }
    }
}
