using Impulse.Common.Models.Application;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkApplication : IUnitOfWork
	{
		IRepository<ProfileUser> ProfilesUsers { get; }
	}
}