using System.Web.Http;
using Impulse.BusinessLogic.BusinessContracts;

namespace WebServices.Controllers
{
	public class BaseApiController : ApiController
	{
		private IBaseManager dataManager;

		public BaseApiController(IBaseManager dataManager)
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