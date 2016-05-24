using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class TipographyService : DataService<Tipography>, ITipographyService
	{
		public TipographyService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}