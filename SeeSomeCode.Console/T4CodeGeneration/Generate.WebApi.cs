
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
		public IEnumerable<ValuesViewModel> GetAll( [FromUri]string filter = "" )
        {
            var resourceModelList = new List<ValuesViewModel>();
            var dm = BizLogic.GetMany( "Values", filter);
		    foreach (var model in dm)
		    {
                resourceModelList.Add(new ValuesViewModel( model.SampleDomainId, "Values" ) { 
					ResourceModelString = model.SampleDomainString 
				});
            }
            return resourceModelList;
        }

		[Route("{id}")]
		public IHttpActionResult GetSingle(int id)
		{
			var domainModel = BizLogic.GetOne( "Values", id.ToString() );
			if ( domainModel == null )
			{
				return NotFound();
			}
            // todo: implement automapper for this        
			return Ok( new ValuesViewModel( domainModel.SampleDomainId, "Values" )
			{
                ResourceModelString = domainModel.SampleDomainString
			});
		}

		[Route("")]
        public HttpResponseMessage Post( [FromBody] ValuesViewModel postValue )
        {
            //DebugMessage("handling post request in controller");
            var domainObject = BizLogic.PostOne("Values", new SampleDto()
            {
                DomainString = postValue.ResourceModelString
            });
			postValue.SetId(domainObject.SampleDomainId, "Values");

            return base.MakeResponse( postValue );
        }

		/// <summary>
		/// ValuesViewModel - resource (view) model
		/// </summary>
		/// <remarks>
		/// Any 
		/// </remarks>
		public class ValuesViewModel
		{
			public int ResourceModelId { get; private set; }
			public IList<WebApiLink> Links { get; private set; }
			[DictionaryElement("ResourceModelString")]
			public string ResourceModelString { get; set; }
			[DictionaryElement("ResourceModelDate")]
			public string ResourceModelDate { get; set; }
			[DictionaryElement("ResourceModelStatus")]
			public string ResourceModelStatus { get; set; }

			// POSTED model uses this constructor
            public ValuesViewModel()
            {
                //
            }
			// when we create the model for a GET...
			public ValuesViewModel( int id, string resourceName )
			{
                this.SetId( id, resourceName );
			}

			// when returning a POSTed model we need to set the key
		    public void SetId( int id, string resourceName )
		    {
                ResourceModelId = id;
		        if (Links == null)
		        {
                    Links = new List<WebApiLink>();
                }
                Links.Add( new WebApiLink( id, resourceName ) );
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
		public IEnumerable<MembersViewModel> GetAll( [FromUri]string filter = "" )
        {
            var resourceModelList = new List<MembersViewModel>();
            var dm = BizLogic.GetMany( "Members", filter);
		    foreach (var model in dm)
		    {
                resourceModelList.Add(new MembersViewModel( model.SampleDomainId, "Members" ) { 
					ResourceModelString = model.SampleDomainString 
				});
            }
            return resourceModelList;
        }

		[Route("{id}")]
		public IHttpActionResult GetSingle(int id)
		{
			var domainModel = BizLogic.GetOne( "Members", id.ToString() );
			if ( domainModel == null )
			{
				return NotFound();
			}
            // todo: implement automapper for this        
			return Ok( new MembersViewModel( domainModel.SampleDomainId, "Members" )
			{
                ResourceModelString = domainModel.SampleDomainString
			});
		}

		[Route("")]
        public HttpResponseMessage Post( [FromBody] MembersViewModel postValue )
        {
            //DebugMessage("handling post request in controller");
            var domainObject = BizLogic.PostOne("Members", new SampleDto()
            {
                DomainString = postValue.ResourceModelString
            });
			postValue.SetId(domainObject.SampleDomainId, "Members");

            return base.MakeResponse( postValue );
        }

		/// <summary>
		/// MembersViewModel - resource (view) model
		/// </summary>
		/// <remarks>
		/// Any 
		/// </remarks>
		public class MembersViewModel
		{
			public int ResourceModelId { get; private set; }
			public IList<WebApiLink> Links { get; private set; }
			[DictionaryElement("ResourceModelString")]
			public string ResourceModelString { get; set; }

			// POSTED model uses this constructor
            public MembersViewModel()
            {
                //
            }
			// when we create the model for a GET...
			public MembersViewModel( int id, string resourceName )
			{
                this.SetId( id, resourceName );
			}

			// when returning a POSTed model we need to set the key
		    public void SetId( int id, string resourceName )
		    {
                ResourceModelId = id;
		        if (Links == null)
		        {
                    Links = new List<WebApiLink>();
                }
                Links.Add( new WebApiLink( id, resourceName ) );
            }
		}
    }
}

