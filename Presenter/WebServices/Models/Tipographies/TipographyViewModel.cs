using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Tipographies
{
	public class TipographyViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Image { get; set; }
	}
}