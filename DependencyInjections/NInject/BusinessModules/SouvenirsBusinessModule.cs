using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.BusinessLogic.Components.Souvenirs;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class SouvenirsBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ICategoryManager>().To<CategoryManager>();
			Bind<ISouvenirManager>().To<SouvenirManager>();
		}
	}
}
