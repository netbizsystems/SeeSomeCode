
using Owin;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json.Serialization;
using SeeSomeCode.T4Depends;
using System.Web.Http.Cors;

namespace SeeSomeCode
{
    /// <summary>
    /// SeeStartup - setup owin application , 
    /// </summary>
    public class SeeStartup
    {
        public void Configuration( IAppBuilder appBuilder )
        {
            HttpConfiguration config = new HttpConfiguration();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // see attributes on individual controllers
            config.MapHttpAttributeRoutes(); 

            // inject (something) into apicontroller
            config.DependencyResolver = new ResolveApiController();

            // Other configuration omitted
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            //filters
            config.Filters.Add( new SeeExceptionFilter() );
            config.Filters.Add( new SeeActionFilter() );

            appBuilder.UseWebApi( config );
        }

        /// <summary>
        /// ResolveApiController - inject dependency into apicontroller
        /// </summary>
        private class ResolveApiController : IDependencyResolver
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

        /// <summary>
        /// SeeActionFilter - respond to validation errors
        /// </summary>
        private class SeeActionFilter : System.Web.Http.Filters.ActionFilterAttribute
        {
            /// <summary>
            /// OnActionExecuting - model attributes (if any) have been processed and may have found an error(s)
            /// </summary>
            /// <param name="actionContext"></param>
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                var api = (BaseApiController<ISeeBusinessLogic>)actionContext.ControllerContext.Controller;
                api.BizLogic.DiagnosticService.WriteTrace("action executing");

                if (actionContext.Request.Method.Method.ToUpper() == "POST")
                {
                    if (!actionContext.ModelState.IsValid)
                    {
                        api.BizLogic.DiagnosticService.WriteTrace("validation failed");
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                    }
                    else
                    {
                        api.BizLogic.DiagnosticService.WriteTrace("validation succeeded");
                    }
                }


                base.OnActionExecuting(actionContext);
            }

            /// <summary>
            /// OnActionExecuted - 
            /// </summary>
            /// <param name="executedContext"></param>
            public override void OnActionExecuted(HttpActionExecutedContext executedContext)
            {
                var api = (BaseApiController<ISeeBusinessLogic>)executedContext.ActionContext.ControllerContext.Controller;
                if (true)
                {
                    api.BizLogic.DiagnosticService.WriteTrace("action executed");                    
                }

                base.OnActionExecuted(executedContext);
            }

        }

        /// <summary>
        /// SeeExceptionFilter - respond to exceptions
        /// </summary>
        private class SeeExceptionFilter : System.Web.Http.Filters.ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext exceptionContext)
            {
                var api = (BaseApiController<ISeeBusinessLogic>)exceptionContext.ActionContext.ControllerContext.Controller;

                if (true)
                {
                    api.BizLogic.DiagnosticService.WriteTrace("exception was handled by global handler");
                    exceptionContext.Response = exceptionContext.Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, exceptionContext.Exception);
                }

                base.OnException(exceptionContext);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class SeeAuthFilter : AuthorizationFilterAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                base.OnAuthorization(actionContext);
            }
        }
    }

}