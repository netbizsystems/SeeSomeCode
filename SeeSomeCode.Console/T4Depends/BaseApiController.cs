using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace SeeSomeCode
{
    /// <summary>
    /// BaseApiController - provide consistent access to biz from api controller(s)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract partial class BaseApiController<T> : ApiController where T : ISeeBusinessLogic
    {
        public T BizLogic { get; private set; }

        private BaseApiController() { /* parmless not allowed */ }

        /// <summary>
        /// BaseApiController
        /// </summary>
        /// <param name="bizLogic"></param>
        public BaseApiController( T bizLogic )
        {
            BizLogic = bizLogic;
            try
            {
                BizLogic.DoSomething();
            }
            catch { /* eat it for this demo */ }
        }

        /// <summary>
        /// HttpResponseMessage
        /// </summary>
        /// <returns></returns>
        protected HttpResponseMessage MakeResponse()
        {
            var hrm = new HttpResponseMessage( ModelState.IsValid ? HttpStatusCode.Accepted : HttpStatusCode.InternalServerError )
            {
                ReasonPhrase = ModelState.IsValid ? "valid" : "not valid"
            };

            return hrm;
        }
    }
}