using Impulse.BusinessLogic.BusinessContracts.Souvenirs;
using Impulse.Common.Models.Souvenirs;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Souvenirs
{
	public class SouvenirManager : DataManager<Souvenir>, ISouvenirManager
	{
		protected IUnitOfWorkSouvenirs unitOfWork;

		public SouvenirManager(IUnitOfWorkSouvenirs unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}