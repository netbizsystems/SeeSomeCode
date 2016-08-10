
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

// GENERATED CODE - SEE GENERATE.WEBAPI.TT FOR DISCUSSION
namespace SeeSomeCode
{
    /// <summary>
    /// REST Resource - Values
    /// </summary>
	[RoutePrefix("api/Values")]
    public partial class ValuesController : BaseApiController<ISeeBusinessLogic>
    {
        public ValuesController( ISeeBusinessLogic bizLogic ) : base( bizLogic ) { }

		[Route("")]
		public IEnumerable<object> GetAll()
        {
            return BizLogic.GetMany("Values");
        }

		[Route("{id}")]
		public IHttpActionResult GetSingle(int id)
		{
			var resourceSingle = BizLogic.GetOne( "Values", "123" );
			if ( resourceSingle == null )
			{
				return NotFound();
			}
			return Ok( resourceSingle );
		}

		[Route("")]
        public HttpResponseMessage Post( [FromBody] ViewModel postValue )
        {
            //DebugMessage("handling post request in controller");

            //BizLogic.DoSomething();

            return base.MakeResponse();
        }
    }
}

