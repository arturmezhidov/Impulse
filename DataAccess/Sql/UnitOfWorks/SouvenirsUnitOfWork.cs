using Impulse.Common.Models.Souvenirs;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class SouvenirsUnitOfWork : UnitOfWork, IUnitOfWorkSouvenirs
	{
		private IRepository<Souvenir> souvenirs;
		private IRepository<Category> categories;

		public SouvenirsUnitOfWork(string stringConnection)
			: base(new SouvenirsDataContext(stringConnection))
		{
		}

		public IRepository<Souvenir> Souvenirs
		{
			get
			{
				return souvenirs ?? (souvenirs = new BaseRepository<Souvenir>(Context));
			}
		}

		public IRepository<Category> Categories
		{
			get
			{
				return categories ?? (categories = new BaseRepository<Category>(Context));
			}
		}

		public override IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(Souvenir))
			{
				return (IRepository<T>)Souvenirs;
			}
			if (typeof(T) == typeof(Category))
			{
				return (IRepository<T>)Categories;
			}
			return null;
		}
	}
}