using Impulse.BusinessLogic.BusinessContracts;
using Impulse.BusinessLogic.Components;
using Ninject.Modules;

namespace Impulse.DependencyInjections.NInjectResolver
{
	public class BusinessModules : NinjectModule
	{
		public override void Load()
		{
			Bind<IUserManager>().To<ApplicationUserManager>();

			Bind<ISlideService>().To<SlideService>();

			Bind<IEmailService>().To<EmailService>();
			Bind<IPhoneService>().To<PhoneService>();
			Bind<ISocialService>().To<SocialService>();
			Bind<IAddressService>().To<AddressService>();

			Bind<IAdvertsCategoryService>().To<AdvertsCategoryService>();
			Bind<IAdvertService>().To<AdvertService>();
			Bind<IAdvertsOrderService>().To<AdvertsOrderService>();

			Bind<IServiceCategoryService>().To<ServiceCategoryService>();
			Bind<IServicesService>().To<ServicesService>();
			Bind<IServiceOrderService>().To<ServiceOrderService>();

			Bind<ISouvenirCategoryService>().To<SouvenirCategoryService>();
			Bind<ISouvenirService>().To<SouvenirService>();
			Bind<ISouvenirOrderService>().To<SouvenirOrderService>();

			Bind<IStendCategoryService>().To<StendCategoryService>();
			Bind<IStendService>().To<StendService>();
			Bind<IStendOrderService>().To<StendOrderService>();

			Bind<ITipographyCategoryService>().To<TipographyCategoryService>();
			Bind<ITipographyService>().To<TipographyService>();

			Bind<IOurWorksFolderService>().To<OurWorksFolderService>();
			Bind<IOurWorksItemService>().To<OurWorksItemService>();

			Bind<IPhotoServicesService>().To<PhotoServicesService>();
		}
	}
}