using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class AdvertsGuestOrderViewModel
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Contacts { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		public int Count { get; set; }

		public double Width { get; set; }

		public double Height { get; set; }

		public int AdvertId { get; set; }
	}
}