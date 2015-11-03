using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anothar.OpenTripPlannerClient
{

    public class Polygon
    {
        public String Type { get; set; }

        public GeoCoordinate[][] Coordinates { get; set; }
    }
}
