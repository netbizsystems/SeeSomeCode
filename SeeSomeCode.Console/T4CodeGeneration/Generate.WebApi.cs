
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SeeSomeCode.T4Depends;

// GENERATED CODE - SEE GENERATE.WEBAPI.TT FOR DISCUSSION
namespace SeeSomeCode.Api
{
    /// <summary>
    /// REST Resource - Values
    /// </summary>
	[RoutePrefix("api/Values")]
    public partial class ValuesController : BaseApiController<ISeeBusinessLogic>
    {
        public ValuesController( ISeeBusinessLogic bizLogic ) : base( bizLogic ) { }

		[Route("")]
		public IEnumerable<ValuesViewModel> GetAll()
        {
            var viewModelList = new List<ValuesViewModel>();
            var dm = BizLogic.GetMany("Values");
		    foreach (var model in dm)
		    {
                viewModelList.Add(new ValuesViewModel() {ViewModelId = 1, ViewModelString = "view model string"});

            }
            return viewModelList;
        }

		[Route("{id}")]
		public IHttpActionResult GetSingle(int id)
		{
			var domainModel = BizLogic.GetOne( "Values", "123" );
			if ( domainModel == null )
			{
				return NotFound();
			}
            // todo: implement automapper for this        
			return Ok( new ValuesViewModel()
			{
			    ViewModelId = domainModel.SampleDomainId,
                ViewModelString = domainModel.SampleDomainString
			} );
		}

		[Route("")]
        public HttpResponseMessage Post( [FromBody] SampleDto postValue )
        {
            //DebugMessage("handling post request in controller");

            //BizLogic.DoSomething();

            return base.MakeResponse();
        }
		/// <summary>
		/// ValuesViewModel - with builtin validation
		/// </summary>
		/// <remarks>
		/// Any DictionaryElement attributes seen below will be processed BEFORE the API method is called. If the model fails
		/// validation, based on the validationmaster, the mothod will not be called at all and a response with error details will be returned.
		/// </remarks>
		public class ValuesViewModel
		{
			public int ViewModelId { get; set; }

			[DictionaryElement("FooName")]
			public string ViewModelString { get; set; }
		}
    }
}

// GENERATED CODE - SEE GENERATE.WEBAPI.TT FOR DISCUSSION
namespace SeeSomeCode.Api
{
    /// <summary>
    /// REST Resource - Members
    /// </summary>
	[RoutePrefix("api/Members")]
    public partial class MembersController : BaseApiController<ISeeBusinessLogic>
    {
        public MembersController( ISeeBusinessLogic bizLogic ) : base( bizLogic ) { }

		[Route("")]
		public IEnumerable<MembersViewModel> GetAll()
        {
            var viewModelList = new List<MembersViewModel>();
            var dm = BizLogic.GetMany("Values");
		    foreach (var model in dm)
		    {
                viewModelList.Add(new MembersViewModel() {ViewModelId = 1, ViewModelString = "view model string"});

            }
            return viewModelList;
        }

		[Route("{id}")]
		public IHttpActionResult GetSingle(int id)
		{
			var domainModel = BizLogic.GetOne( "Values", "123" );
			if ( domainModel == null )
			{
				return NotFound();
			}
            // todo: implement automapper for this        
			return Ok( new MembersViewModel()
			{
			    ViewModelId = domainModel.SampleDomainId,
                ViewModelString = domainModel.SampleDomainString
			} );
		}

		[Route("")]
        public HttpResponseMessage Post( [FromBody] SampleDto postValue )
        {
            //DebugMessage("handling post request in controller");

            //BizLogic.DoSomething();

            return base.MakeResponse();
        }
		/// <summary>
		/// MembersViewModel - with builtin validation
		/// </summary>
		/// <remarks>
		/// Any DictionaryElement attributes seen below will be processed BEFORE the API method is called. If the model fails
		/// validation, based on the validationmaster, the mothod will not be called at all and a response with error details will be returned.
		/// </remarks>
		public class MembersViewModel
		{
			public int ViewModelId { get; set; }

			[DictionaryElement("FooName")]
			public string ViewModelString { get; set; }
		}
    }
}

