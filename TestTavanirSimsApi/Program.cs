using MyNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestTavanirSimsApi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var username = "user";
                
                var password = "pass";
                

                var simsApi = new SimsApiClient(new HttpClient());
                
                simsApi.BaseUrl = "https://sims.tavanir.org.ir/ws/";

                var authResp = await simsApi.AuthenticateAsync(new AuthenticateRequest()
                { Username = username, Password = password });

                if (authResp.Success != true)
                {
                    Console.WriteLine("Authentication failed");
                }

                var cyclesResp = await simsApi.GetCyclesAsync(new ApiRequestBase() { Token = authResp.Token });
                if (cyclesResp.Success == true)
                {
                    foreach (var cycleData in cyclesResp.Data)
                    {
                        Console.WriteLine(cycleData.Title);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
