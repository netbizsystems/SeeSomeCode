using Owin;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System;
using System.CodeDom;
using System.Collections.Generic;

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
            public IDependencyScope BeginScope()
            {
                return this;
            }

            public void Dispose()
            {
                return;
            }

            public object GetService(Type serviceType)
            {
                if (serviceType.BaseType != null && serviceType.BaseType.IsGenericType)
                {
                    return Activator.CreateInstance( serviceType, new SeeBusinessLogic() );
                }
                return null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return new List<object>();
            }
        }
    }

    public class SeeBusinessLogic
    {
        public SeeBusinessLogic() { }
    }
}