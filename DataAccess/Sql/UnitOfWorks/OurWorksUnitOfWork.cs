using Impulse.Common.Models.OurWorks;
using Impulse.DataAccess.DataContracts;
using Impulse.DataAccess.Sql.DataContexts;
using Impulse.DataAccess.Sql.Repositories;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class OurWorksUnitOfWork : UnitOfWork, IUnitOfWorkOurWorks
	{
		private IRepository<Item> items;
		private IRepository<Folder> folders;

		public OurWorksUnitOfWork(string stringConnection)
			: base(new OurWorksDataContext(stringConnection))
		{
		}

		public IRepository<Item> Items
		{
			get
			{
				return items ?? (items = new BaseRepository<Item>(Context));
			}
		}

		public IRepository<Folder> Folders
		{
			get
			{
				return folders ?? (folders = new BaseRepository<Folder>(Context));
			}
		}

		public override IRepository<T> GetRepository<T>()
		{
			if (typeof(T) == typeof(Item))
			{
				return (IRepository<T>)Items;
			}
			if (typeof(T) == typeof(Folder))
			{
				return (IRepository<T>)Folders;
			}
			return null;
		}
	}
}