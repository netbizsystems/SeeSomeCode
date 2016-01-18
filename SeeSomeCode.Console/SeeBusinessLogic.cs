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
        public virtual object SeeService1
        {
            get
            {
                return _seeService1.Value;
            }
        }
        private readonly Lazy<object> _seeService1 = new Lazy<object>(() => new object());

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
        object SeeService2 { get; }
        object SeeService1 { get; }
        void DoSomething();
        string SeeProperty { get; set; }
    }
}