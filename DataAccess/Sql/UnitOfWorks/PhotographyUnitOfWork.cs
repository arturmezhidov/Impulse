using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.Photography;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

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
			throw new System.NotImplementedException();
		}
	}
}