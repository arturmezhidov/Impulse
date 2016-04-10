using Impulse.Common.Models.Services;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class ServicesUnitOfWork : UnitOfWork, IUnitOfWorkServices
	{
		private IRepository<Service> services;
		private IRepository<Category> categories;

		public ServicesUnitOfWork(string stringConnection)
			: base(new ServicesDataContext(stringConnection))
		{
		}

		public IRepository<Service> Services
		{
			get
			{
				return services ?? (services = new BaseRepository<Service>(Context));
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
			if (typeof(T) == typeof(Service))
			{
				return (IRepository<T>)Services;
			}
			if (typeof(T) == typeof(Category))
			{
				return (IRepository<T>)Categories;
			}
			return null;
		}
	}
}