
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace SeeCodeNow
{
    public class Program
    {
        static void Main()
        {
            string baseAddress = @"http://localhost:9000/";

            using ( WebApp.Start<Startup>( url: baseAddress ) )
            {
                System.Diagnostics.Trace.TraceInformation(TraceMessage.GetMessageText("starting"));
                HttpClient client = new HttpClient();
                var postResponse = client
                    .PostAsJsonAsync( baseAddress + "api/values", new ValuesController.ValuePostDto() )
                    .Result;

                Console.ReadLine();
                System.Diagnostics.Trace.TraceInformation(TraceMessage.GetMessageText("ending"));
            }
        }
    }

    public class TraceMessage
    {
        public static string GetMessageText( string text )
        {
            return string.Format( "Hello {0} at the hour of {1}", text, DateTime.Now.ToShortDateString() );
        }
    }
}