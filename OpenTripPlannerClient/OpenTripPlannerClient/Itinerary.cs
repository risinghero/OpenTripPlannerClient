using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// Route
    /// </summary>
    /// <seealso cref="http://dev.opentripplanner.org/apidoc/0.15.0/ns0_itinerary.html"/>
    public class Itinerary
    {
        /// <summary>
        /// Duration of the trip
        /// </summary>
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Time that the trip departs
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Time that the trip arrives
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// How much time is spent walking
        /// </summary>
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan WalkTime { get; set; }

        /// <summary>
        /// How much time is spent on transit
        /// </summary>
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan TransitTime { get; set; }

        /// <summary>
        /// How much time is spent waiting for transit to arrive
        /// </summary>
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan WaitingTime { get; set; }

        /// <summary>
        /// How far the user has to walk, in meters. 
        /// </summary>
        public double? WalkDistance { get; set; }

        /// <summary>
        /// Indicates that the walk limit distance has been exceeded for this itinerary when true. 
        /// </summary>
        [JsonProperty("walkLimitExceeded")]
        public bool IsWalkLimitExceeded { get; set; }

        /// <summary>
        /// How much elevation is lost, in total, over the course of the trip, in meters. As an example, a trip that went from the top of Mount Everest straight down to sea level, then back up K2, then back down again would have an elevationLost of Everest + K2. 
        /// </summary>
        public double? ElevationLost { get; set; }

        /// <summary>
        /// How much elevation is gained, in total, over the course of the trip, in meters. See elevationLost. 
        /// </summary>
        public double? ElevationGained { get; set; }

        /// <summary>
        /// The number of transfers this trip has.
        /// </summary>
        public int? Transfers { get; set; }

        /// <summary>
        /// A list of Legs. Each Leg is either a walking (cycling, car) portion of the trip, or a transit trip on a particular vehicle. So a trip where the use walks to the Q train, transfers to the 6, then walks to their destination, has four legs. 
        /// </summary>
        public Leg[] Legs { get; set; }

        /// <summary>
        /// This itinerary has a greater slope than the user requested (but there are no possible itineraries with a good slope). 
        /// </summary>
        [JsonProperty("tooSloped")]
        public bool IsTooSloped { get; set; }
    }
}
