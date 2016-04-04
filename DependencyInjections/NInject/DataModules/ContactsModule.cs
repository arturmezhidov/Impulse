using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.UnitOfWorks;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.DataModules
{
	public class ContactsModule : NinjectModule
	{
		private readonly string connectionString;

		public ContactsModule(string connectionString)
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