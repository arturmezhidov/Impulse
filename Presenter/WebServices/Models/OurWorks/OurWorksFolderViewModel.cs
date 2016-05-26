using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		public List<OurWorksItem> Items { get; set; }

		public OurWorksFolderViewModel()
		{
			Items = new List<OurWorksItem>();
		}
	}
}