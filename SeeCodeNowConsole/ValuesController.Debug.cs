using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace SeeCodeNow
{
    public partial class ValuesController : BaseApiController
    {
        /// <summary>
        /// DebugMessage - will not generate any bits in the assembly
        /// </summary>
        partial void DebugMessage();
#if DEBUG
        /// <summary>
        /// DebugMessage - in debug mode it will generate those bits
        /// </summary>
        partial void DebugMessage()
        {
            System.Diagnostics.Trace.TraceInformation(TraceMessage.GetMessageText("TomTom"));
        }
    }
#endif
}