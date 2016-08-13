
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SeeSomeCode.T4Depends;

// GENERATED CODE (Values) - SEE GENERATE.WEBAPI.TT FOR DISCUSSION
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
                viewModelList.Add(new ValuesViewModel( model.SampleDomainId, "Values" ) { 
					ViewModelString = model.SampleDomainString 
				});
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
			return Ok( new ValuesViewModel( domainModel.SampleDomainId, "Values" )
			{
                ViewModelString = domainModel.SampleDomainString
			});
		}

		[Route("")]
        public HttpResponseMessage Post( [FromBody] SampleDto postValue )
        {
            //DebugMessage("handling post request in controller");
            var domainObject = BizLogic.PostOne("", postValue);
            var viewModel = new ValuesViewModel( domainObject.SampleDomainId, "Values" )
            {
                ViewModelString = domainObject.SampleDomainString
            };
            return base.MakeResponse( viewModel );
        }

		/// <summary>
		/// ValuesViewModel - 
		/// </summary>
		/// <remarks>
		/// Any 
		/// </remarks>
		public class ValuesViewModel
		{
			public int ViewModelId { get; private set; }
			public string ViewModelString { get; set; }
			public IList<WebApiLink> Links { get; set; }

			public ValuesViewModel(int id, string resourceName)
			{
				ViewModelId = id;
				Links = new List<WebApiLink>();
                Links.Add(new WebApiLink(id, resourceName));
			}
		}
    }
}

// GENERATED CODE (Members) - SEE GENERATE.WEBAPI.TT FOR DISCUSSION
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
                viewModelList.Add(new MembersViewModel( model.SampleDomainId, "Members" ) { 
					ViewModelString = model.SampleDomainString 
				});
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
			return Ok( new MembersViewModel( domainModel.SampleDomainId, "Members" )
			{
                ViewModelString = domainModel.SampleDomainString
			});
		}

		[Route("")]
        public HttpResponseMessage Post( [FromBody] SampleDto postValue )
        {
            //DebugMessage("handling post request in controller");
            var domainObject = BizLogic.PostOne("", postValue);
            var viewModel = new MembersViewModel( domainObject.SampleDomainId, "Members" )
            {
                ViewModelString = domainObject.SampleDomainString
            };
            return base.MakeResponse( viewModel );
        }

		/// <summary>
		/// MembersViewModel - 
		/// </summary>
		/// <remarks>
		/// Any 
		/// </remarks>
		public class MembersViewModel
		{
			public int ViewModelId { get; private set; }
			public string ViewModelString { get; set; }
			public IList<WebApiLink> Links { get; set; }

			public MembersViewModel(int id, string resourceName)
			{
				ViewModelId = id;
				Links = new List<WebApiLink>();
                Links.Add(new WebApiLink(id, resourceName));
			}
		}
    }
}

