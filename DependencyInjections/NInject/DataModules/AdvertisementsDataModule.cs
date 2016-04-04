using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class AdvertisementsDataModule : NinjectModule
	{
		private readonly string connectionString;

		public AdvertisementsDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkAdvertisements>()
				.To<AdvertisementsUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}