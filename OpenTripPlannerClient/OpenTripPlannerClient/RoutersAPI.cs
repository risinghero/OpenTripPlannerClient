using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// Routers management api
    /// </summary>
    /// <seealso cref="http://dev.opentripplanner.org/apidoc/0.15.0/resource_Routers.html#path__routers.html"/>
    public class RoutersAPI
    {
        private readonly HttpClient _client;
        private DateTime _unixStartDate= new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
       
        public RoutersAPI(HttpClient client)
        {
            _client = client;
        }

        public async Task<Router[]> GetAllAsync()
        {
            using (var stream = await _client.GetStreamAsync("routers"))
            {
                var routersList = new List<Router>();
                var dynamicRoutes = stream.Deserialize<dynamic>();
                foreach (var routerInfo in dynamicRoutes.routerInfo)
                {
                    var id = (String)routerInfo.routerId;
                    var buildTime = (long)routerInfo.buildTime;
                    var coordinates = new List<GeoCoordinate[]>();
                    var type = (String)routerInfo.polygon.type;
                    foreach (var coordArray in routerInfo.polygon.coordinates)
                    {
                        var internalCoorList = new List<GeoCoordinate>();
                        foreach (var internalCoordArray in coordArray)
                        {
                            internalCoorList.Add(new GeoCoordinate(
                                (double)internalCoordArray[1],
                                (double)internalCoordArray[0]));
                        };
                        coordinates.Add(internalCoorList.ToArray());
                    }
                    routersList.Add(new Router
                    {
                        Id=id,
                        BuildTime = 
                        _unixStartDate.AddMilliseconds(buildTime).ToLocalTime(),
                        Polygon = new Polygon
                        {
                            Type = type,
                            Coordinates = coordinates.ToArray()
                        }
                    });
                }
                return routersList.ToArray();
            }
        }
    }
}
