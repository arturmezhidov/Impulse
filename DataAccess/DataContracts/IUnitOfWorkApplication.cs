using Impulse.Common.Models.Application;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkApplication : IUnitOfWork
	{
		IRepository<ProfileUser> ProfilesUsers { get; }
		IRepository<Address> Addresses { get; }
		IRepository<Email> Emails { get; }
		IRepository<Phone> Phones { get; }
		IRepository<Social> Socials { get; }
	}
}