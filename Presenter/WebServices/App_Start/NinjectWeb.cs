using Impulse.Presenter.WebServices;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]

namespace Impulse.Presenter.WebServices
{
	public static class NinjectWeb 
	{
		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start() 
		{
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
		}
	}
}
