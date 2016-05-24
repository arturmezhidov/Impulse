using System.Web.Http;
using Impulse.Presenter.WebServices.Filters;

namespace Impulse.Presenter.WebServices
{
	public class FiltersConfig
	{
		public static void RegisterGlobalFilters(HttpConfiguration config)
		{
			config.Filters.Add(new ExceptionLoggerAttribute());
		}
	}
}