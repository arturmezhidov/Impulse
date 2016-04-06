using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.Contacts;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

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
			throw new System.NotImplementedException();
		}
	}
}