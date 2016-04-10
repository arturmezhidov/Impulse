using Impulse.BusinessLogic.BusinessContracts.Photography;
using Impulse.BusinessLogic.Components.Photography;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class PhotographyBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IPhotoServiceManager>().To<PhotoServiceManager>();
		}
	}
}
