using System;

namespace Anothar.OpenTripPlannerClient
{
    internal static class UnixTime
    {
        private static DateTime _unixStartDate = 
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);

        public static DateTime ToDateTime(long value)
        {
            return _unixStartDate.AddMilliseconds(value);
        }

        public static long FromDateTime(DateTime date)
        {
            return (long)(date- _unixStartDate).TotalMilliseconds;
        }
    }
}
