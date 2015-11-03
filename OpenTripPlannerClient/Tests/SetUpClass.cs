using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using NUnit.Framework;

namespace Anothar.OpenTripPlannerClient.Tests
{
    /// <summary>
    /// Class to start OTP
    /// </summary>
    [SetUpFixture]
    public class SetUpClass
    {
        public const int Port = 13114;
        private Process _process;

        /// <summary>
        /// Starting OTP Instance
        /// </summary>
        [SetUp]
        public void StartOTP()
        {
            var path =Path.Combine(Path.GetFullPath(Environment.CurrentDirectory),"Data");
            //starting OTP
            _process=Process.Start(new ProcessStartInfo
            {
                WorkingDirectory = path,
                Arguments = $"-Xmx1G -jar otp-0.18.0.jar --build \"{path}\" --port {Port} --inMemory",
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName= "java"
            });
          
            var count = 0;
            const int MaxCount = 10000;
            HttpWebResponse response=null;
            //waiting while started
            do
            {
                Thread.Sleep(50);
                try {
                    var request = HttpWebRequest.Create("http://localhost:" + Port + "/");
                    response = request.GetResponse() as HttpWebResponse;
                }
                catch(System.Net.WebException)
                {

                }
                count++;
            } while ((response==null|| response.StatusCode != HttpStatusCode.OK)&&count<MaxCount);
            if (count >= MaxCount)
                throw new ApplicationException("OTP connect timeout");
            OTPClient.DefaultConnectionUrl = "http://localhost:" + Port + "/";
        }

        /// <summary>
        /// Shutting down OTP Instance
        /// </summary>
        [TearDown]
        public void StopOTP()
        {
            if(_process!=null&&!_process.HasExited)
                _process.Kill();
        }
    }
}
