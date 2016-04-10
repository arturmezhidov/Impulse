using Impulse.BusinessLogic.BusinessContracts.Stends;
using Impulse.BusinessLogic.Components.Stends;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class StendsBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ICategoryManager>().To<CategoryManager>();
			Bind<IMaterialManager>().To<MaterialManager>();
			Bind<IStendManager>().To<StendManager>();
		}
	}
}
