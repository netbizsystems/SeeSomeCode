using System;

namespace SeeSomeCode
{
    /// <summary>
    /// SeeBusinessLogic - for DI into ApiController
    /// </summary>
    public class SeeBusinessLogic : ISeeBusinessLogic
    {
        #region services (lots of them maybe)
        /// <summary>
        /// DiagnosticService - if needed here it is!
        /// </summary>
        public virtual DiagnosticService DiagnosticService
        {
            get
            {
                return _seeService1.Value;
            }
        }
        private readonly Lazy<DiagnosticService> _seeService1 = new Lazy<DiagnosticService>(() => new DiagnosticService());

        /// <summary>
        /// DataService - if needed here it is!
        /// </summary>
        public virtual object DataService
        {
            get
            {
                return _dataService.Value;
            }
        }
        private readonly Lazy<object> _dataService = new Lazy<object>(() => new object());
        #endregion

        public string SeeProperty { get; set; } = "see ?";

        /// <summary>
        /// SeeBusinessLogic - constructor
        /// </summary>
        public SeeBusinessLogic() { }
        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// ISeeBusinessLogic
    /// </summary>
    public interface ISeeBusinessLogic
    {
        DiagnosticService DiagnosticService { get; }
        object DataService { get; }
        void DoSomething();
        string SeeProperty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DiagnosticService
    {
        public void WriteTrace(string traceMessageText)
        {
            System.Diagnostics.Trace.TraceInformation( FormatTraceMessage((traceMessageText)) );
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