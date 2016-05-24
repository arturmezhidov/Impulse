using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class SlideViewModel
	{
		public int Id { get; set; }

		[MaxLength(1024)]
		[Required]
		public string Image { get; set; }

		[MaxLength(1024)]
		public string Url { get; set; }

		[MaxLength(1024)]
		public string About { get; set; }
	}
}