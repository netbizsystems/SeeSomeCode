
using System.Diagnostics;

namespace SeeSomeCode
{
    public partial class ValuesController
    {
        /// <summary>
        /// DebugMessage - will not generate any bits in the assembly
        /// </summary>
        partial void DebugMessage(string debugMessage);

#if DEBUG
        /// <summary>
        /// DebugMessage - in debug mode it will generate those bits
        /// </summary>
        partial void DebugMessage(string debugMessage)
        {
            Trace.TraceInformation(TraceMessage.GetMessageText( debugMessage ));
        }
    }
#endif
}