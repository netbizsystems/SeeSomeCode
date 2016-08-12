using System;

namespace SeeSomeCode
{
    /// <summary>
    /// 
    /// </summary>
    public class DiagnosticService
    {
        public void WriteTrace(string traceMessageText)
        {
            System.Diagnostics.Trace.TraceInformation(FormatTraceMessage((traceMessageText)));
        }

        private string FormatTraceMessage(string traceMessageText)
        {
            return string.Format("[{0}] - [{1}] -- {2}"
                , DateTime.Now.ToShortDateString()
                , DateTime.Now.ToLongTimeString()
                , traceMessageText);
        }
    }
}