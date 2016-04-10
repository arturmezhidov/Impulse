using Impulse.Common.Models.Stends;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class StendsUnitOfWork : UnitOfWork, IUnitOfWorkStends
	{
		private IRepository<Stend> stends;
		private IRepository<Category> categories;
		private IRepository<Material> materials;

		public StendsUnitOfWork(string stringConnection)
			: base(new StendsDataContext(stringConnection))
		{
		}

		public IRepository<Stend> Stends
		{
			get
			{
				return stends ?? (stends = new BaseRepository<Stend>(Context));
			}
		}

		public IRepository<Category> Categories
		{
			get
			{
				return categories ?? (categories = new BaseRepository<Category>(Context));
			}
		}

		public IRepository<Material> Materials
		{
			get
			{
				return materials ?? (materials = new BaseRepository<Material>(Context));
			}
		}

		public override IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(Stend))
			{
				return (IRepository<T>)Stends;
			}
			if (typeof(T) == typeof(Category))
			{
				return (IRepository<T>)Categories;
			}
			if (typeof(T) == typeof(Material))
			{
				return (IRepository<T>)Materials;
			}
			return null;
		}
	}
}