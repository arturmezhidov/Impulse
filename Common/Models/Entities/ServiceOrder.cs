namespace Impulse.Common.Models.Entities
{
	public class ServiceOrder : BaseOrder
	{
		public string Address { get; set; }

		public int ServiceId { get; set; }
		public virtual Service Service { get; set; }
	}
}