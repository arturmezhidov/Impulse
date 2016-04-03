using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;

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
			Bind<IUnitOfWorkAdvertisements>()
				.To<AdvertisementsUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkContacts>()
				.To<ContactsUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkOurWorks>()
				.To<OurWorksUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkPhotography>()
				.To<PhotographyUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkServices>()
				.To<ServicesUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkShop>()
				.To<ShopUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkSouvenirs>()
				.To<SouvenirsUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkStends>()
				.To<StendsUnitOfWork>()
				.WithConstructorArgument(connectionString);
			Bind<IUnitOfWorkTipographies>()
				.To<TipographiesUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}