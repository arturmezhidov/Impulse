namespace Impulse.Common.Models.Entities
{
	public class AdvertsGuestOrder : BaseGuestOrder
	{
		public int Count { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }

		public int AdvertId { get; set; }
		public virtual Advert Advert { get; set; }
	}
}
