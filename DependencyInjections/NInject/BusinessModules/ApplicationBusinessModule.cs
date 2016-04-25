﻿using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.BusinessLogic.Components.Application;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class ApplicationBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IUserManager>().To<UsersManager>();
		}
	}
}
