
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace SeeSomeCode
{
    public class SeeProgram
    {
        static void Main()
        {
            string baseAddress = @"http://localhost:9000/";

            using ( WebApp.Start<SeeStartup>( url: baseAddress ) )
            {
                System.Diagnostics.Trace.TraceInformation(TraceMessage.GetMessageText("starting"));
                HttpClient client = new HttpClient();
                var postResponse = client
                    .PostAsJsonAsync( baseAddress + "api/values", new ValuesController.PostDTO() )
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
            return string.Format("SeeProgram says [{0}] at the hour of [{1}]", text, DateTime.Now.ToShortDateString() );
        }
    }
}