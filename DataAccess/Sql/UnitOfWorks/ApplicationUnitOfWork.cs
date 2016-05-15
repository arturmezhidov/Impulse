using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class ApplicationUnitOfWork : UnitOfWork, IUnitOfWorkApplication
	{
		private IRepository<ProfileUser> profilesUsers;
		private IRepository<Address> addresses;
		private IRepository<Email> emails;
		private IRepository<Phone> phones;
		private IRepository<Social> socials;
		private IRepository<Slide> slides;

		public ApplicationUnitOfWork(string stringConnection)
			: base(new ApplicationDataContext(stringConnection))
		{
		}

		public IRepository<ProfileUser> ProfilesUsers
		{
			get
			{
				return profilesUsers ?? (profilesUsers = new BaseRepository<ProfileUser>(Context));
			}
		}

		public IRepository<Address> Addresses
		{
			get
			{
				return addresses ?? (addresses = new BaseRepository<Address>(Context));
			}
		}

		public IRepository<Email> Emails
		{
			get
			{
				return emails ?? (emails = new BaseRepository<Email>(Context));
			}
		}

		public IRepository<Phone> Phones
		{
			get
			{
				return phones ?? (phones = new BaseRepository<Phone>(Context));
			}
		}

		public IRepository<Social> Socials
		{
			get
			{
				return socials ?? (socials = new BaseRepository<Social>(Context));
			}
		}

		public IRepository<Slide> Slides
		{
			get
			{
				return slides ?? (slides = new BaseRepository<Slide>(Context));
			}
		}
	}
}