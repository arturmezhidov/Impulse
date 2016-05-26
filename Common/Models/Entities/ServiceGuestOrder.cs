namespace Impulse.Common.Models.Entities
{
	public class ServiceGuestOrder : BaseGuestOrder
	{
		public string Address { get; set; }

		public int ServiceId { get; set; }
		public virtual Service Service { get; set; }
	}
}