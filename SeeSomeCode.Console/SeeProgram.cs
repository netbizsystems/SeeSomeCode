
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace SeeSomeCode
{
    /// <summary>
    /// SeeProgram - console application with self-hosted api
    /// </summary>
    /// <remarks>
    /// Once this server is runing, try plugging url into your browser
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
                biz.DiagnosticService.WriteTrace( "starting" );  
                              
                HttpClient client = new HttpClient();
                try
                {
                    var postResponse = client.PostAsJsonAsync(baseAddress + "api/values", new ValuesController.PostDTO()).Result;
                }
                catch { /* eat it for now */ }

                Console.ReadLine();

                biz.DiagnosticService.WriteTrace( "ending" );
            }
        }
    }
}