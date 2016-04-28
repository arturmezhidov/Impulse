using System.Web.Http;
using Impulse.Presenter.WebServices.Filters;

namespace WebServices.App_Start
{
	public class FiltersConfig
	{
		public static void RegisterGlobalFilters(HttpConfiguration config)
		{
			config.Filters.Add(new ExceptionLoggerAttribute());
		}
	}
}