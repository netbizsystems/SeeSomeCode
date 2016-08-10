
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SeeSomeCode
{
    /// <summary>
    /// SeeProgram - console application with self-hosted api
    /// </summary>
    /// <remarks>
    /// Once this server is runing, try plugging url into your browser (or Postman)
    /// http://localhost:9000/api/values
    /// http://localhost:9000/api/values/1
    /// </remarks>
    public class SeeProgram
    {
        static void Main()
        {
            string baseAddress = @"http://localhost:9000/";
            var biz = new SeeBusinessLogic() as ISeeBusinessLogic;

            using ( WebApp.Start<SeeStartup>( url: baseAddress ) )
            {
                biz.DiagnosticService.WriteTrace( "starting to listen on localhost:9000" );
                RunAsync(baseAddress).Wait();
                Console.ReadLine();
                biz.DiagnosticService.WriteTrace( "ending listener" );
            }
        }

        static async Task RunAsync(string baseAddress)
        {
            using (var client = new HttpClient())
            {
                var postResponse = client.PostAsJsonAsync(baseAddress + "api/values", new ViewModel() { ViewModelId = 123, ViewModelString = "xxx"}).Result;

                //var getSingleResponse = await client.GetAsync(baseAddress + "api/values/1");
                //if (getResponse.IsSuccessStatusCode)
                //{
                //    //Product product = await response.Content.ReadAsAsync > Product > ();
                //    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                //}

                //var getListResponse = await client.GetAsync(baseAddress + "api/values");
                //if (getResponse.IsSuccessStatusCode)
                //{
                //    //Product product = await response.Content.ReadAsAsync > Product > ();
                //    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                //}
            }

            //HttpClient client = new HttpClient();
            //try
            //{
            //    var postResponse = client.PostAsJsonAsync( baseAddress + "api/values", new object() ).Result;
            //}
            //catch (Exception e) { /* eat it for now */ }
        }
    }
}