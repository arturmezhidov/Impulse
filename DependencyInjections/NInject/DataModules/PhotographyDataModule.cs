using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class PhotographyDataModule : NinjectModule
	{
		private readonly string connectionString;

		public PhotographyDataModule(string connectionString)
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