using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.OurWorks;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

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
	}
}