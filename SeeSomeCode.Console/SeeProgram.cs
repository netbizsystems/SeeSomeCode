
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace SeeSomeCode
{
    /// <summary>
    /// SeeProgram - console application with self-hosted api
    /// </summary>
    public class SeeProgram
    {
        public static object Dka = new object();

        static void Main()
        {
            string baseAddress = @"http://localhost:9000/";
            var biz = new SeeBusinessLogic() as ISeeBusinessLogic;

            using ( WebApp.Start<SeeStartup>( url: baseAddress ) )
            {
                biz.SeeService1.WriteTrace( "starting" );  
                              
                HttpClient client = new HttpClient();

                try
                {
                    var postResponse = client.PostAsJsonAsync(baseAddress + "api/values", new ValuesController.PostDTO()).Result;
                }
                catch { /* eat it for now */ }

                Console.ReadLine();

                biz.SeeService1.WriteTrace( "ending" );
            }
        }
    }
}