using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class SouvenirsDataModule : NinjectModule
	{
		private readonly string connectionString;

		public SouvenirsDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkSouvenirs>()
				.To<SouvenirsUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}