using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class PhoneViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Operator { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }
	}
}