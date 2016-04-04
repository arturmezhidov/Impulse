using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class ShopDataModule : NinjectModule
	{
		private readonly string connectionString;

		public ShopDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkShop>()
				.To<ShopUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}