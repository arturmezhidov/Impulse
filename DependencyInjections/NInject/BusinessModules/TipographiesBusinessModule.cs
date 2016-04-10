using Impulse.BusinessLogic.BusinessContracts.Tipographies;
using Impulse.BusinessLogic.Components.Tipographies;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class TipographiesBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IKindManager>().To<KindManager>();
			Bind<ITipographyManager>().To<TipographyManager>();
		}
	}
}