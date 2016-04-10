using Impulse.BusinessLogic.BusinessContracts.Contacts;
using Impulse.BusinessLogic.Components.Contacts;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver.BusinessModules
{
	public class ContactsBusinessModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IAddressManager>().To<AddressManager>();
			Bind<IEmailManager>().To<EmailManager>();
			Bind<IPhoneManager>().To<PhoneManager>();
			Bind<ISocialManager>().To<SocialManager>();
		}
	}
}