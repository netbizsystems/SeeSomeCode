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

    /// <summary>
    /// ValuesController
    /// </summary>
    [RoutePrefix("api/values")]
    public partial class ValuesController : BaseApiController<ISeeBusinessLogic>
    {
        /// <summary>
        /// ValuesController - constructor with DI parameter
        /// </summary>
        /// <param name="bizLogic"></param>
        public ValuesController( ISeeBusinessLogic bizLogic ) : base( bizLogic ) { }

        [Route("")]
        public IEnumerable<GetDTO> Get()
        {
            DebugMessage("handling get request");

            return new GetDTO[] { new GetDTO() };
        }

        [Route("{id}")]
        public GetDTO Get( int id )
        {
            DebugMessage(string.Format( "handling get request for [{0}]", id ));

            return new GetDTO();
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="postValue"></param>
        /// <returns>HttpResponseMessage</returns>
        /// <remarks>
        /// The model is valid by the time we get here.. see the global filter for that. Also, no need to catch any exception 
        /// from the biz.logic as a global filter catches that for us.
        /// </remarks>
        [Route("")]
        public HttpResponseMessage Post( [FromBody] PostDTO postValue )
        {
            DebugMessage("handling post request in controller");

            BizLogic.DoSomething();

            return base.MakeResponse();
        }

        public class GetDTO
        {
            public int DtoId { get; set; } = 100;
            public string DtoName { get; set; } = "onetwothree";
        }

        public class PostDTO
        {
            [Required] [DictionaryElement("DtoId")]
            public int DtoId { get; set; } = 100;

            [Required] [DictionaryElement("FooName")]
            public string DtoName { get; set; } = "onetwothree";
        }
    }
}