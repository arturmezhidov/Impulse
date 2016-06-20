using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Impulse.Common.Components.Loggers;

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