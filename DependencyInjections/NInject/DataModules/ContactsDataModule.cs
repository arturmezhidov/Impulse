using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class ContactsDataModule : NinjectModule
	{
		private readonly string connectionString;

		public ContactsDataModule(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public override void Load()
		{
			Bind<IUnitOfWorkContacts>()
				.To<ContactsUnitOfWork>()
				.WithConstructorArgument(connectionString);
		}
	}
}