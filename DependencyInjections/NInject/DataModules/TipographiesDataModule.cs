using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class TipographiesDataModule : NinjectModule
	{
		private readonly string connectionString;

		public TipographiesDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkTipographies>()
				.To<TipographiesUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}