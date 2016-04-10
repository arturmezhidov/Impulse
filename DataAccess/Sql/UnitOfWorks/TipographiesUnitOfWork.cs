using Impulse.Common.Models.Tipographies;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

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

		public override IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(Tipography))
			{
				return (IRepository<T>)Tipographies;
			}
			if (typeof(T) == typeof(Kind))
			{
				return (IRepository<T>)Kinds;
			}
			return null;
		}
	}
}