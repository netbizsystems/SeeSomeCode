
using System.Web.Http;
using System.Net.Http;
using System.Net;
using SeeSomeCode.Api;
using System;

namespace SeeSomeCode.T4Depends
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

        internal HttpResponseMessage MakeResponse(object viewModel)
        {
            //var hrm = new HttpResponseMessage(ModelState.IsValid ? HttpStatusCode.Accepted : HttpStatusCode.InternalServerError)
            //{
            //    ReasonPhrase = ModelState.IsValid ? "valid" : "not valid"
            //};

            var response = Request.CreateResponse(ModelState.IsValid ? HttpStatusCode.Accepted : HttpStatusCode.InternalServerError, viewModel);

            return response;
        }
    }
}