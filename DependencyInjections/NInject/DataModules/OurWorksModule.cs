﻿using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class OurWorksModule : NinjectModule
	{
		private readonly string connectionString;

		public OurWorksModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkOurWorks>()
				.To<OurWorksUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}