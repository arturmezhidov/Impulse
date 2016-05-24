using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class AddressViewModel
	{
		public int Id { get; set; }

		[MaxLength(1024)]
		public string Country { get; set; }

		[MaxLength(1024)]
		public string Region { get; set; }

		[Required]
		[MaxLength(1024)]
		public string City { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Street { get; set; }

		[Required]
		[MaxLength(1024)]
		public string House { get; set; }

		public double Longitube { get; set; }

		public double Latitube { get; set; }
	}
}