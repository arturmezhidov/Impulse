using System.Web.Http;
using Impulse.Common.Components.Loggers;
using WebServices;
using WebServices.App_Start;

namespace Impulse.Presenter.WebServices
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			GlobalConfiguration.Configure(FiltersConfig.RegisterGlobalFilters);
			FileLogger.InitLogger();
		}
	}
}