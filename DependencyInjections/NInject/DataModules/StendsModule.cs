using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class StendsModule : NinjectModule
	{
		private readonly string connectionString;

		public StendsModule(string connectionString)
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