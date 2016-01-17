
using Owin;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SeeSomeCode
{
    /// <summary>
    /// SeeStartup - setup owin application 
    /// </summary>
    public class SeeStartup
    {
        public void Configuration( IAppBuilder appBuilder )
        {
            HttpConfiguration config = new HttpConfiguration();

            // see attributes on individual controllers
            config.MapHttpAttributeRoutes(); 

            // inject (something) into apicontroller
            config.DependencyResolver = new ResolveApiController();

            appBuilder.UseWebApi( config );
        }

        /// <summary>
        /// ResolveApiController - inject dependency into apicontroller
        /// </summary>
        public class ResolveApiController : IDependencyResolver
        {
            public object GetService(Type serviceType)
            {
                if (serviceType.BaseType != null && serviceType.BaseType.IsGenericType)
                {

                    return Activator.CreateInstance( serviceType, new SeeBusinessLogic() );
                }
                return null;
            }

            #region nothing to see here
            public IDependencyScope BeginScope() { return this; }
            public void Dispose() { return; }
            public IEnumerable<object> GetServices(Type serviceType) { return new List<object>(); } 
            #endregion
        }
    }

    /// <summary>
    /// SeeBusinessLogic - for DI into ApiController
    /// </summary>
    public class SeeBusinessLogic : ISeeBusinessLogic
    {
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
        void DoSomething();
        string SeeProperty { get; set; }
    }

}