using Impulse.BusinessLogic.BusinessContracts.Services;
using Impulse.BusinessLogic.Components.Services;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class ServicesBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ICategoryManager>().To<CategoryManager>();
			Bind<IServiceManager>().To<ServiceManager>();
		}
	}
}
