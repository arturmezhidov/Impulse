using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver
{
	public class DataAccessModule : NinjectModule
	{
		private readonly string connectionString;

		public DataAccessModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWork>()
				.To<UnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}