using Owin;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System;
using System.Collections.Generic;

namespace SeeCodeNow
{
    public class Startup
    {
        public void Configuration( IAppBuilder appBuilder )
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new ResolveApiController();

            appBuilder.UseWebApi( config );
        }

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
                if (serviceType.BaseType == typeof(BaseApiController))
                {
                    return Activator.CreateInstance(serviceType, 123);
                }
                return null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return new List<object>();
            }
        }
    }
}