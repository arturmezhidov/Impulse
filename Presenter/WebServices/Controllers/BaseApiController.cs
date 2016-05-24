using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;

namespace Impulse.Presenter.WebServices.Controllers
{
	public class BaseApiController : ApiController
	{
		private readonly IBaseService dataManager;

		public BaseApiController(IBaseService dataManager)
		{
			this.dataManager = dataManager;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				dataManager.Dispose();
			}
		}
	}
}