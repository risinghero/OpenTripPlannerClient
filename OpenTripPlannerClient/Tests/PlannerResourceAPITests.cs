using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Anothar.OpenTripPlannerClient.Tests
{
    [TestFixture]
    public class PlannerResourceAPITests
    {
        [Test]
        public async Task TestPlan()
        {
            using (var client = new OTPClient())
            {
                var plan = await client.Planner.Plan(new PlanRequest
                {
                    FromPlace = new GeoCoordinate(52.599535278374645, 13.290302753448486),
                    ToPlace = new GeoCoordinate(52.58200889177419, 13.358602523803711),
                    Mode = "CAR"
                });
                Assert.AreEqual("Titusweg", plan.Plan.From.Name);
                Assert.AreEqual("NORMAL", plan.Plan.From.VertexType);
                Assert.AreEqual("Markscheiderstraße", plan.Plan.To.Name);
                Assert.AreEqual("NORMAL", plan.Plan.To.VertexType);
                Assert.IsTrue(plan.Plan.From.Coordinate.Latitude > 50);
                Assert.IsTrue(plan.Plan.From.Coordinate.Longitude > 13);
                Assert.AreEqual(1,plan.Plan.Itineraries[0].Legs.Length);
                var geometry = plan.Plan.Itineraries[0].Legs[0].Geometry.GetPoints().ToArray();
                Assert.IsTrue(geometry.All(p=>p.Latitude>50&&p.Longitude>13));
            }
        }
    }
}
