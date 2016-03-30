using System;
using Impulse.Common.Models.Contacts;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkContacts : IUnitOfWork
	{
		IRepository<Address> Addresses { get; }
		IRepository<Email> Emails { get; }
		IRepository<Phone> Phones { get; }
		IRepository<Social> Socials { get; }
	}
}
