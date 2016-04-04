using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class PhotographyModule : NinjectModule
	{
		private readonly string connectionString;

		public PhotographyModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkPhotography>()
				.To<PhotographyUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}