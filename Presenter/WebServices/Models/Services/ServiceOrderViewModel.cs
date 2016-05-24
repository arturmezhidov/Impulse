using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Services
{
	public class ServiceOrderViewModel
	{
		[MaxLength(2048)]
		public string Description { get; set; }

		public string Address { get; set; }

		public int ServiceId { get; set; }
	}
}