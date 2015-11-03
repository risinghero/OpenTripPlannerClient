using Newtonsoft.Json;
using System.IO;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// Internal Json.Net Extensions to simplify coding
    /// </summary>
    static class JsonNetExtensions
    {
        public static T Deserialize<T>(this Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<T>(reader);
            }
        }
    }
}
