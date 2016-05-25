using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;

namespace Impulse.Presenter.WebServices.Controllers
{
	public class BaseApiController<T> : ApiController where T : class, new()
	{
		protected readonly IDataService<T> DataService;

		public BaseApiController(IDataService<T> dataService)
		{
			DataService = dataService;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				DataService.Dispose();
			}
		}
	}
}