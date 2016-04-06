using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.Souvenirs;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

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
			throw new System.NotImplementedException();
		}
	}
}