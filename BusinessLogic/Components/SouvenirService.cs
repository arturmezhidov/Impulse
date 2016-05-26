using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class SouvenirService : DataService<Souvenir>, ISouvenirService
	{
		public SouvenirService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}