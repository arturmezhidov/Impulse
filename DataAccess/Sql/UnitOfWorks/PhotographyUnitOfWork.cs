using Impulse.Common.Models.Photography;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class PhotographyUnitOfWork : UnitOfWork, IUnitOfWorkPhotography
	{
		private IRepository<PhotoService> photoServices;

		public PhotographyUnitOfWork(string stringConnection)
			: base(new PhotographyDataContext(stringConnection))
		{
		}

		public IRepository<PhotoService> PhotoServices
		{
			get
			{
				return photoServices ?? (photoServices = new BaseRepository<PhotoService>(Context));
			}
		}

		public override IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(PhotoService))
			{
				return (IRepository<T>)PhotoServices;
			}
			return null;
		}
	}
}