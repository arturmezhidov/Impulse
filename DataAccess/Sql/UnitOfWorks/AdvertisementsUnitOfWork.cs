using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.DataAccess.DataContracts;
using Impulse.Common.Models.Advertisements;
using Impulse.DataAccess.Sql.Repositories;
using Impulse.DataAccess.Sql.DataContexts;

namespace Impulse.DataAccess.Sql.UnitOfWorks
{
	public class AdvertisementsUnitOfWork : UnitOfWork, IUnitOfWorkAdvertisements
	{
		private IRepository<Advert> adverts;
		private IRepository<Type> types;
		private IRepository<Material> materials;

		public AdvertisementsUnitOfWork(string stringConnection)
			: base(new AdvertisementsDataContext(stringConnection))
		{
		}

		public IRepository<Advert> Adverts
		{
			get
			{
				return adverts ?? (adverts = new BaseRepository<Advert>(Context));
			}
		}

		public IRepository<Type> Types
		{
			get
			{
				return types ?? (types = new BaseRepository<Type>(Context));
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
			if (typeof(T) == typeof(Type))
			{
				return (IRepository<T>)Types;
			}
			if (typeof(T) == typeof(Material))
			{
				return (IRepository<T>)Materials;
			}
			if (typeof(T) == typeof(Advert))
			{
				return (IRepository<T>)Adverts;
			}
			return null;
		}
	}
}