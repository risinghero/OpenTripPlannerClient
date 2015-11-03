using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anothar.OpenTripPlannerClient
{
    /// <summary>
    /// Router
    /// </summary>
    /// <seealso cref="http://dev.opentripplanner.org/apidoc/0.15.0/ns0_routerInfo.html"/>
    public class Router
    {
        public String Id { get; set; }

        public Polygon Polygon { get; set; }

        public DateTime? BuildTime { get; set; }
    }
}
