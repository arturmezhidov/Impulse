using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class AdvertCategoryViewModel
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

		public IQueryable<AdvertViewModel> Adverts { get; set; }
	}
}