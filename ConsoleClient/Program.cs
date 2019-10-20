using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        public const string CommandAndControlUrl = "https://localhost:5001/api";

        private static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            InstanceInfo.InstanceId = Guid.NewGuid().ToString("D");
            

            Console.WriteLine("FTP Client...");
            Console.WriteLine("");
            Console.WriteLine($"Instance Id = {InstanceInfo.InstanceId}");
            Console.WriteLine($"Machine Name = {Environment.MachineName}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Registering client with Command and Control...");

            if (await RegisterFtpClient())
            {
                while (true)
                {
                    Thread.Sleep(30000); // sleep for 30 seconds
                    Console.WriteLine("Checking new orders...");

                    // code to check new orders
                }
            }
            
        }

        private static async Task<bool> RegisterFtpClient()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "FTP Client");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var model = new Shared.FtpClientModel 
                {
                    InstanceId = InstanceInfo.InstanceId, 
                    MachineName = Environment.MachineName
                };

            var modelStr = JsonSerializer.Serialize(model, new JsonSerializerOptions{Encoder = JavaScriptEncoder.Default});
            try
            {
                var message = await httpClient.PostAsync($"{CommandAndControlUrl}/FtpClient/register-client", new StringContent(modelStr, Encoding.UTF8, "application/json"));
                message.EnsureSuccessStatusCode();
                Console.WriteLine("Ftp Client registered and waiting for orders...");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ftp Client was not able to register itself on Command and Control, program will be terminated now");
                Console.WriteLine(e.Message);
                Thread.Sleep(5000);
            }

            return false;

        }
    }
}
