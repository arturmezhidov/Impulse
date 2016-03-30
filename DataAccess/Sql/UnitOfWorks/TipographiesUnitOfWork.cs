using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.Tipographies;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class TipographiesUnitOfWork : UnitOfWork, IUnitOfWorkTipographies
	{
		private IRepository<Tipography> tipographies;
		private IRepository<Kind> kinds;

		public TipographiesUnitOfWork(string stringConnection)
			: base(new TipographiesDataContext(stringConnection))
		{
		}

		public IRepository<Tipography> Tipographies
		{
			get
			{
				return tipographies ?? (tipographies = new BaseRepository<Tipography>(Context));
			}
		}

		public IRepository<Kind> Kinds
		{
			get
			{
				return kinds ?? (kinds = new BaseRepository<Kind>(Context));
			}
		}
	}
}