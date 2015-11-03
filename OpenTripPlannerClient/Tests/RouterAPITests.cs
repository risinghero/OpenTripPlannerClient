using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Anothar.OpenTripPlannerClient.Tests
{
    [TestFixture]
    public class OtpClientTests
    {
        [Test]
        public async Task TestGetAll()
        {
            using (var client = new OTPClient())
            {
                var routers=await client.Routers.GetAllAsync();
                Assert.AreEqual(1, routers.Length);
                Assert.AreEqual(String.Empty,routers[0].Id);
                Assert.IsTrue(routers[0].Polygon!=null);
                Assert.IsTrue(routers[0].BuildTime > DateTime.Now.AddDays(-1));
            }
        }
    }
}
