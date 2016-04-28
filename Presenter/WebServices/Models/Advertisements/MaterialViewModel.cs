using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class MaterialViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }
	}
}