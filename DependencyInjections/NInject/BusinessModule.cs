using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Impulse.BusinessLogic.Components.Advertisements;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;

namespace Impulse.DependencyInjections.NInjectResolver
{
	public class BusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IAdvertsManager>().To<AdvertsManager>();
		}
	}
}
