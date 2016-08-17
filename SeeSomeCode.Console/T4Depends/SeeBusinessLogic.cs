
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SeeSomeCode.T4Depends
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

        public SampleDomain GetOne(string resourceName, string resourceId)
        {
            return new SampleDomain() { SampleDomainId  = int.Parse( resourceId ), SampleDomainString = "sample domain string"};
        }

        public IEnumerable<SampleDomain> GetMany(string resourceName, string filter = "")
        {
            var listOfMany = new List<SampleDomain>();

            listOfMany.Add(new SampleDomain() { SampleDomainId = 1, SampleDomainString = "sample values domain string" });
            listOfMany.Add(new SampleDomain() { SampleDomainId = 2, SampleDomainString = "sample values domain string" });
            listOfMany.Add(new SampleDomain() { SampleDomainId = 3, SampleDomainString = "sample values domain string" });

            return listOfMany;
        }

        public SampleDomain PostOne(string resourceName, SampleDto postDto)
        {
            return new SampleDomain()
            {
                SampleDomainId = 99,
                SampleDomainString = postDto.DomainString
            };
        }
    }
}