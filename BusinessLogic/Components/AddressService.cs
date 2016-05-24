using Impulse.BusinessLogic.BusinessContracts;
using Impulse.Common.Models.Entities;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components
{
	public class AddressService : DataService<Address>, IAddressService
	{
		public AddressService(IUnitOfWork uow) : base(uow)
		{
		}
	}
}