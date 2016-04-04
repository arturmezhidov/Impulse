using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class ServicesModule : NinjectModule
	{
		private readonly string connectionString;

		public ServicesModule(string connectionString)
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