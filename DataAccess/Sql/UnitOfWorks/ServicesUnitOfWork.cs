using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.Services;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

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
	}
}