namespace Impulse.Common.Models.Entities
{
	public class StendGuestOrder : BaseGuestOrder
	{
		public int Count { get; set; }

		public int StendId { get; set; }
		public virtual Stend Stend { get; set; }
	}
}