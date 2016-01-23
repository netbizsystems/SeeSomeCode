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
        /// SeeService1 - if needed here it is!
        /// </summary>
        public virtual Service1 SeeService1
        {
            get
            {
                return _seeService1.Value;
            }
        }
        private readonly Lazy<Service1> _seeService1 = new Lazy<Service1>(() => new Service1());

        /// <summary>
        /// SeeService2 - if needed here it is!
        /// </summary>
        public virtual object SeeService2
        {
            get
            {
                return _seeService2.Value;
            }
        }
        private readonly Lazy<object> _seeService2 = new Lazy<object>(() => new object());
        #endregion

        public string SeeProperty { get; set; } = "see ?";
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
        Service1 SeeService1 { get; }
        object SeeService2 { get; }
        void DoSomething();
        string SeeProperty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Service1
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