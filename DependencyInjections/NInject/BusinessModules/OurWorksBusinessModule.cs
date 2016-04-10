using Impulse.BusinessLogic.BusinessContracts.OurWorks;
using Impulse.BusinessLogic.Components.OurWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class OurWorksBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IFolderManager>().To<FolderManager>();
			Bind<IItemManager>().To<ItemManager>();
		}
	}
}
