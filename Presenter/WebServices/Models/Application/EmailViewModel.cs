using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Application
{
	public class EmailViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Address { get; set; }
	}
}