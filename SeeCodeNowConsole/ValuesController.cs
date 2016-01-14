using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace SeeCodeNow
{
    public abstract partial class BaseApiController : ApiController
    {
        public BaseApiController() { /* parmless not allowed */ }

        protected HttpResponseMessage MakeResponse()
        {
            var hrm = new HttpResponseMessage( ModelState.IsValid ? HttpStatusCode.Accepted : HttpStatusCode.InternalServerError )
            {
                ReasonPhrase = "hello tom"
            };

            return hrm;
        }
    }

    [RoutePrefix( "api/values" )]
    public partial class ValuesController : BaseApiController
    {
        public ValuesController(int notUsed)
        {
            return;
        }

        [Route("")]
        public IEnumerable<ValueGetDto> Get()
        {
            return new ValueGetDto[] { new ValueGetDto() };
        }

        [Route( "{id}"  )]
        public ValueGetDto Get( int id )
        {
            return new ValueGetDto();
        }

        [Route( "" )]
        public HttpResponseMessage Post( [FromBody] ValuePostDto postValue )
        {
            DebugMessage();

            if( ModelState.IsValid )
            {
                // do something
            }
            return base.MakeResponse();
        }

        public class ValueGetDto
        {
            public int DtoId { get; set; } = 100;
            public string DtoName { get; set; } = "onetwothree";
        }

        public class ValuePostDto
        {
            public int DtoId { get; set; } = 100;

            [DictionaryElement("FooName")]
            public string DtoName { get; set; } = "onetwothree";
        }
    }
}