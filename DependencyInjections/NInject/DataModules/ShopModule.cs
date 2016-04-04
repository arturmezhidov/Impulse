using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class ShopModule : NinjectModule
	{
		private readonly string connectionString;

		public ShopModule(string connectionString)
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