using Impulse.Common.Models.Contacts;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class ContactsUnitOfWork : UnitOfWork, IUnitOfWorkContacts
	{
		private IRepository<Address> addresses;
		private IRepository<Email> emails;
		private IRepository<Phone> phones;
		private IRepository<Social> socials;

		public ContactsUnitOfWork(string stringConnection)
			: base(new ContactsDataContext(stringConnection))
		{
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

		public override IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(Address))
			{
				return (IRepository<T>)Addresses;
			}
			if (typeof(T) == typeof(Email))
			{
				return (IRepository<T>)Emails;
			}
			if (typeof(T) == typeof(Phone))
			{
				return (IRepository<T>)Phones;
			}
			if (typeof(T) == typeof(Social))
			{
				return (IRepository<T>)Socials;
			}
			return null;
		}
	}
}