using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class ApplicationUnitOfWork : UnitOfWork, IUnitOfWorkApplication
	{
		private IRepository<ProfileUser> profilesUsers;

		public ApplicationUnitOfWork(string stringConnection)
			: base(new AdvertisementsDataContext(stringConnection))
		{
		}

		public IRepository<ProfileUser> ProfilesUsers
		{
			get
			{
				return profilesUsers ?? (profilesUsers = new BaseRepository<ProfileUser>(Context));
			}
		}


		public override IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(ProfileUser))
			{
				return (IRepository<T>)ProfilesUsers;
			}
			return null;
		}
	}
}