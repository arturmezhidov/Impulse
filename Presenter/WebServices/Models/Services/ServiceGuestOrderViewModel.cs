using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Services
{
	public class ServiceGuestOrderViewModel
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Contacts { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		public string Address { get; set; }

		public int ServiceId { get; set; }
	}
}