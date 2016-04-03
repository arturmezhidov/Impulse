using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Impulse.Common.Models.Advertisements;
using Impulse.DataAccess.DataContracts;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;

namespace Impulse.BusinessLogic.Components.Advertisements
{
	public class AdvertsManager : IAdvertsManager
	{
		protected IUnitOfWorkAdvertisements unitOfWork;

		public AdvertsManager(IUnitOfWorkAdvertisements unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IQueryable<Advert> Dislplay()
		{
			return unitOfWork.Adverts.GetAll();
		}

		public void Dispose()
		{
			if (unitOfWork != null)
			{
				unitOfWork.Dispose();
			}
		}

		public void Add()
		{
			unitOfWork.Types.Add(new Common.Models.Advertisements.Type() { Name = "ffw", Description = "fefe", Icon = "feefe"});
		}
	}
}