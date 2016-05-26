using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Stends
{
	public class StendCategoryViewModel
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

		public List<StendViewModel> Stends { get; set; }

		public StendCategoryViewModel()
		{
			Stends = new List<StendViewModel>();
		}
	}
}