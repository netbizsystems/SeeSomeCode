
using System.Diagnostics;

namespace SeeSomeCode.Api
{
    public partial class ValuesController
    {
#if DEBUG
        /// <summary>
        /// DebugMessage - in debug mode it will generate those bits
        /// </summary>
        partial void DebugMessage( string debugMessage)
        {
            base.BizLogic.DiagnosticService.WriteTrace( debugMessage );
        }
    }
#endif
}