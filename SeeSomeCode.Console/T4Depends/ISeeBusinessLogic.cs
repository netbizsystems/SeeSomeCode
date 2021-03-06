
using System.Collections.Generic;

namespace SeeSomeCode.T4Depends
{
    /// <summary>
    /// ISeeBusinessLogic
    /// </summary>
    public interface ISeeBusinessLogic
    {
        DiagnosticService DiagnosticService { get; }
        object DataService { get; }
        void DoSomething();
        string SeeProperty { get; set; }
        SampleDomain GetOne(string resourceName, string resourceId);
        IEnumerable<SampleDomain> GetMany(string resourceName, string filter);
        SampleDomain PostOne(string resourceName, SampleDto postDto);
    }
}