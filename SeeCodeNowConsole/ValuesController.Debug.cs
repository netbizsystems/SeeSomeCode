using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace SeeCodeNow
{
    public partial class ValuesController : BaseApiController
    {
        partial void DebugMessage();
#if DEBUG
        partial void DebugMessage()
        {
            System.Diagnostics.Trace.TraceInformation(TraceMessage.GetMessageText("TomTom"));
        }
    }
#endif
}