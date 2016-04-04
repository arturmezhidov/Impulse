using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class ServicesDataModule : NinjectModule
	{
		private readonly string connectionString;

		public ServicesDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkServices>()
				.To<ServicesUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}