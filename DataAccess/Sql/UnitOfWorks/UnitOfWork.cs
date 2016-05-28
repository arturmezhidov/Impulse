using System;
using System.Linq;
using System.Reflection;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly EntityDataContext Context;
		private bool disposed;

		private IUserStore<ApplicationUser> applicationUsers;
		private IRepository<ProfileUser> profilesUsers;
		private IRepository<Address> addresses;
		private IRepository<Email> emails;
		private IRepository<Phone> phones;
		private IRepository<Social> socials;
		private IRepository<Slide> slides;

		private IRepository<Advert> adverts;
		private IRepository<AdvertsCategory> advertsCategories;
		private IRepository<AdvertsOrder> advertsOrders;
		private IRepository<AdvertsGuestOrder> advertsGuestOrders;

		private IRepository<Service> services;
		private IRepository<ServiceCategory> serviceCategories;
		private IRepository<ServiceOrder> serviceOrders;
		private IRepository<ServiceGuestOrder> serviceGuestOrders;

		private IRepository<Souvenir> souvenirs;
		private IRepository<SouvenirCategory> souvenirCategories;
		private IRepository<SouvenirOrder> souvenirOrders;
		private IRepository<SouvenirGuestOrder> souvenirGuestOrders;

		private IRepository<Stend> stends;
		private IRepository<StendCategory> stendCategories;
		private IRepository<StendOrder> stendOrders;
		private IRepository<StendGuestOrder> stendGuestOrders;

		private IRepository<Tipography> tipographies;
		private IRepository<TipographyCategory> tipographyCategories;

		private IRepository<OurWorksItem> ourWorksItems;
		private IRepository<OurWorksFolder> ourWorksFolders;

		private IRepository<PhotoService> photoServices;

		private IRepository<Feedback> feedbacks;

		public IUserStore<ApplicationUser> ApplicationUsers
		{
			get
			{
				return applicationUsers ?? (applicationUsers = new UserStore<ApplicationUser>(Context));
			}
		}
		public IRepository<ProfileUser> ProfilesUsers
		{
			get
			{
				return profilesUsers ?? (profilesUsers = new Repository<ProfileUser>(Context));
			}
		}
		public IRepository<Address> Addresses
		{
			get
			{
				return addresses ?? (addresses = new Repository<Address>(Context));
			}
		}
		public IRepository<Email> Emails
		{
			get
			{
				return emails ?? (emails = new Repository<Email>(Context));
			}
		}
		public IRepository<Phone> Phones
		{
			get
			{
				return phones ?? (phones = new Repository<Phone>(Context));
			}
		}
		public IRepository<Social> Socials
		{
			get
			{
				return socials ?? (socials = new Repository<Social>(Context));
			}
		}
		public IRepository<Slide> Slides
		{
			get
			{
				return slides ?? (slides = new Repository<Slide>(Context));
			}
		}

		public IRepository<Advert> Adverts
		{
			get
			{
				return adverts ?? (adverts = new Repository<Advert>(Context));
			}
		}
		public IRepository<AdvertsCategory> AdvertsCategories
		{
			get
			{
				return advertsCategories ?? (advertsCategories = new Repository<AdvertsCategory>(Context));
			}
		}
		public IRepository<AdvertsOrder> AdvertsOrders
		{
			get
			{
				return advertsOrders ?? (advertsOrders = new Repository<AdvertsOrder>(Context));
			}
		}
		public IRepository<AdvertsGuestOrder> AdvertsGuestOrders
		{
			get
			{
				return advertsGuestOrders ?? (advertsGuestOrders = new Repository<AdvertsGuestOrder>(Context));
			}
		}

		public IRepository<Service> Services
		{
			get
			{
				return services ?? (services = new Repository<Service>(Context));
			}
		}
		public IRepository<ServiceCategory> ServiceCategories
		{
			get
			{
				return serviceCategories ?? (serviceCategories = new Repository<ServiceCategory>(Context));
			}
		}
		public IRepository<ServiceOrder> ServiceOrders
		{
			get
			{
				return serviceOrders ?? (serviceOrders = new Repository<ServiceOrder>(Context));
			}
		}
		public IRepository<ServiceGuestOrder> ServiceGuestOrders
		{
			get
			{
				return serviceGuestOrders ?? (serviceGuestOrders = new Repository<ServiceGuestOrder>(Context));
			}
		}

		public IRepository<Souvenir> Souvenirs
		{
			get
			{
				return souvenirs ?? (souvenirs = new Repository<Souvenir>(Context));
			}
		}
		public IRepository<SouvenirCategory> SouvenirCategories
		{
			get
			{
				return souvenirCategories ?? (souvenirCategories = new Repository<SouvenirCategory>(Context));
			}
		}
		public IRepository<SouvenirOrder> SouvenirOrders
		{
			get
			{
				return souvenirOrders ?? (souvenirOrders = new Repository<SouvenirOrder>(Context));
			}
		}
		public IRepository<SouvenirGuestOrder> SouvenirGuestOrders
		{
			get
			{
				return souvenirGuestOrders ?? (souvenirGuestOrders = new Repository<SouvenirGuestOrder>(Context));
			}
		}

		public IRepository<Stend> Stends
		{
			get
			{
				return stends ?? (stends = new Repository<Stend>(Context));
			}
		}
		public IRepository<StendCategory> StendCategories
		{
			get
			{
				return stendCategories ?? (stendCategories = new Repository<StendCategory>(Context));
			}
		}
		public IRepository<StendOrder> StendOrders
		{
			get
			{
				return stendOrders ?? (stendOrders = new Repository<StendOrder>(Context));
			}
		}
		public IRepository<StendGuestOrder> StendGuestOrders
		{
			get
			{
				return stendGuestOrders ?? (stendGuestOrders = new Repository<StendGuestOrder>(Context));
			}
		}

		public IRepository<Tipography> Tipographies
		{
			get
			{
				return tipographies ?? (tipographies = new Repository<Tipography>(Context));
			}
		}
		public IRepository<TipographyCategory> TipographyCategories
		{
			get
			{
				return tipographyCategories ?? (tipographyCategories = new Repository<TipographyCategory>(Context));
			}
		}

		public IRepository<OurWorksItem> OurWorksItems
		{
			get
			{
				return ourWorksItems ?? (ourWorksItems = new Repository<OurWorksItem>(Context));
			}
		}
		public IRepository<OurWorksFolder> OurWorksFolders
		{
			get
			{
				return ourWorksFolders ?? (ourWorksFolders = new Repository<OurWorksFolder>(Context));
			}
		}

		public IRepository<PhotoService> PhotoServices
		{
			get
			{
				return photoServices ?? (photoServices = new Repository<PhotoService>(Context));
			}
		}

		public IRepository<Feedback> Feedbacks
		{
			get
			{
				return feedbacks ?? (feedbacks = new Repository<Feedback>(Context));
			}
		}

		public UnitOfWork(string connectionString)
		{
			Context = new EntityDataContext(connectionString);
		}

		public virtual IRepository<T> GetRepository<T>() where T : class, new()
		{
			PropertyInfo property = GetType().GetProperties().FirstOrDefault(i => i.PropertyType == typeof (IRepository<T>));
			IRepository<T> result= (IRepository<T>)property.GetValue(this);
			return result;
		}
		public void Save()
		{
			Context.SaveChanges();
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					Context.Dispose();
				}
				disposed = true;
			}
		}
	}
}