namespace Impulse.Common.Models.Entities
{
	public class SouvenirGuestOrder : BaseGuestOrder
	{
		public int Count { get; set; }

		public int SouvenirdId { get; set; }
		public virtual Souvenir Souvenir { get; set; }
	}
}