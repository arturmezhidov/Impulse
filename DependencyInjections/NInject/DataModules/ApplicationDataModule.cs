using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class ApplicationDataModule : NinjectModule
	{
		private readonly string connectionString;

		public ApplicationDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkApplication>()
				.To<ApplicationUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}