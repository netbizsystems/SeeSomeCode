using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace SeeSomeCode
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract partial class BaseApiController<T> : ApiController where T : SeeBusinessLogic
    {
        protected T BizLogic { get; private set; }

        private BaseApiController() { /* parmless not allowed */ }

        /// <summary>
        /// BaseApiController
        /// </summary>
        /// <param name="bizLogic"></param>
        public BaseApiController( T bizLogic )
        {
            BizLogic = bizLogic;
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
    /// 
    /// </summary>
    [RoutePrefix("api/values")]
    public partial class ValuesController : BaseApiController<SeeBusinessLogic>
    {
        /// <summary>
        /// ValuesController - constructor with DI parameter
        /// </summary>
        /// <param name="bizLogic"></param>
        public ValuesController( SeeBusinessLogic bizLogic ) : base( bizLogic ) { }

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

        [Route("")]
        public HttpResponseMessage Post( [FromBody] PostDTO postValue )
        {
            DebugMessage("handling post request");

            if( ModelState.IsValid )
            {
                // do something
            }
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