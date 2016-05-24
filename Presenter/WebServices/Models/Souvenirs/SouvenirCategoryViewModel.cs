using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Souvenirs
{
	public class SouvenirCategoryViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Icon { get; set; }

		public List<SouvenirViewModel> Souvenirs { get; set; }

		public SouvenirCategoryViewModel()
		{
			Souvenirs = new List<SouvenirViewModel>();
		}
	}
}