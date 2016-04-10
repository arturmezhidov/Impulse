using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using Impulse.BusinessLogic.Components.Advertisements;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class AdvertisementsBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<ITypeManager>().To<TypeManager>();
			Bind<IMaterialManager>().To<MaterialManager>();
			Bind<IAdvertManager>().To<AdvertManager>();
		}
	}
}
