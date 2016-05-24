using System.ComponentModel.DataAnnotations;
using System.Linq;
using Impulse.Common.Models.Entities;

namespace Impulse.Presenter.WebServices.Models.OurWorks
{
	public class OurWorksFolderViewModel
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

		public IQueryable<OurWorksItem> Items { get; set; }
	}
}