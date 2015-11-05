using System;
using Newtonsoft.Json;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// One leg of a trip -- that is, a temporally continuous piece of the journey that takes place on a particular vehicle (or on foot). 
    /// </summary>
    /// <seealso cref="http://dev.opentripplanner.org/apidoc/0.15.0/ns0_leg.html"/>
    public class Leg
    {
        /// <summary>
        /// The mode (e.g., Walk) used when traversing this leg. 
        /// </summary>
        public String Mode { get; set; }

        /// <summary>
        /// For transit legs, the route of the bus or train being used. For non-transit legs, the name of the street being traversed. 
        /// </summary>
        public String Route { get; set; }

        public String AgencyName { get; set; }

        public String AgencyUrl { get; set; }

        public int AgencyTimeZoneOffset { get; set; }

        /// <summary>
        /// For transit legs, the type of the route. Non transit -1 When 0-7: 0 Tram, 1 Subway, 2 Train, 3 Bus, 4 Ferry, 5 Cable Car, 6 Gondola, 7 Funicular When equal or highter than 100, it is coded using the Hierarchical Vehicle Type (HVT) codes from the European TPEG standard Also see http://groups.google.com/group/gtfs-changes/msg/ed917a69cf8c5bef 
        /// </summary>
        public RouteType RouteType { get; set; }

        /// <summary>
        /// The date and time this leg begins. 
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The date and time this leg ends. 
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// For transit leg, the offset from the scheduled departure-time of the boarding stop in this leg. "scheduled time of departure at boarding stop" = startTime - departureDelay 
        /// </summary>
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan DepartureDelay { get; set; }

        /// <summary>
        /// For transit leg, the offset from the scheduled arrival-time of the alighting stop in this leg. "scheduled time of arrival at alighting stop" = endTime - arrivalDelay 
        /// </summary>
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan ArrivalDelay { get; set; }

        /// <summary>
        /// Whether there is real-time data about this Leg 
        /// </summary>
        [JsonProperty("realTime")]
        public bool IsRealTime { get; set; }


        /// <summary>
        /// Is this leg a traversing pathways? 
        /// </summary>
        [JsonProperty("pathway")]
        public bool IsPathway { get; set; }

        /// <summary>
        /// Is this a frequency-based trip with non-strict departure times? 
        /// </summary>
        public bool IsNonExactFrequency { get; set; }

        /// <summary>
        /// For transit legs, if the rider should stay on the vehicle as it changes route names. 
        /// </summary>
        [JsonProperty("interlineWithPreviousLeg")]
        public bool IsInterlineWithPreviousLeg { get; set; }

        /// <summary>
        /// The Place where the leg originates. 
        /// </summary>
        public Place From { get; set; }

        /// <summary>
        /// The Place where the leg begins. 
        /// </summary>
        public Place To { get; set; }

        [JsonProperty("rentedBike")]
        public bool IsRentedBike { get; set; }

        /// <summary>
        /// For transit legs, intermediate stops between the Place where the leg originates and the Place where the leg ends. For non-transit legs, null. This field is optional i.e. it is always null unless "showIntermediateStops" parameter is set to "true" in the planner request. 
        /// </summary>
        public Place[] IntermediateStops { get; set; }

        /// <summary>
        /// The leg's duration 
        /// </summary>
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan Duration { get; set; }

        [JsonProperty("transitLeg")]
        public bool IsTransit { get; set; }

        /// <summary>
        /// The leg's geometry. 
        /// </summary>
        [JsonProperty("legGeometry")]
        public EncodedPolylineBean Geometry { get; set; }

        /// <summary>
        /// A series of turn by turn instructions used for walking, biking and driving. 
        /// </summary>
        public TripStep[] Steps { get; set; }
    }
}
