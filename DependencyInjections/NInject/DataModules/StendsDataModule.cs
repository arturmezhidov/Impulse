using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class StendsDataModule : NinjectModule
	{
		private readonly string connectionString;

		public StendsDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkStends>()
				.To<StendsUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}