using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.Stends;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

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
			throw new System.NotImplementedException();
		}
	}
}