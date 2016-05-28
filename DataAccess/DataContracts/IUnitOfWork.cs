using System;
using Microsoft.AspNet.Identity;
using Impulse.Common.Models.Entities;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWork : IDisposable
	{
		IUserStore<ApplicationUser> ApplicationUsers { get; }
		IRepository<ProfileUser> ProfilesUsers { get; }
		IRepository<Address> Addresses { get; }
		IRepository<Email> Emails { get; }
		IRepository<Phone> Phones { get; }
		IRepository<Social> Socials { get; }
		IRepository<Slide> Slides { get; }

		IRepository<Advert> Adverts { get; }
		IRepository<AdvertsCategory> AdvertsCategories { get; }
		IRepository<AdvertsOrder> AdvertsOrders { get; }
		IRepository<AdvertsGuestOrder> AdvertsGuestOrders { get; }

		IRepository<Service> Services { get; }
		IRepository<ServiceCategory> ServiceCategories { get; }
		IRepository<ServiceOrder> ServiceOrders { get; }
		IRepository<ServiceGuestOrder> ServiceGuestOrders { get; }

		IRepository<Souvenir> Souvenirs { get; }
		IRepository<SouvenirCategory> SouvenirCategories { get; }
		IRepository<SouvenirOrder> SouvenirOrders { get; }
		IRepository<SouvenirGuestOrder> SouvenirGuestOrders { get; }

		IRepository<Stend> Stends { get; }
		IRepository<StendCategory> StendCategories { get; }
		IRepository<StendOrder> StendOrders { get; }
		IRepository<StendGuestOrder> StendGuestOrders { get; }

		IRepository<Tipography> Tipographies { get; }
		IRepository<TipographyCategory> TipographyCategories { get; }

		IRepository<OurWorksItem> OurWorksItems { get; }
		IRepository<OurWorksFolder> OurWorksFolders { get; }

		IRepository<PhotoService> PhotoServices { get; }

		IRepository<Feedback> Feedbacks { get; }

		IRepository<T> GetRepository<T>() where T : class, new();
		void Save();
	}
}