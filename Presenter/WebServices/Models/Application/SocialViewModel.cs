using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class SocialViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Url { get; set; }
	}
}