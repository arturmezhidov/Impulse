namespace Impulse.Common.Models.Entities
{
	public class StendGuestOrder : BaseOrder
	{
		public int Count { get; set; }

		public int StendId { get; set; }
		public virtual Stend Stend { get; set; }
	}
}