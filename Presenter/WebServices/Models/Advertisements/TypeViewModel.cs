using System.ComponentModel.DataAnnotations;

using Impulse.Common.Models.Advertisements;

namespace WebServices.Models.Advertisements
{
	public class TypeViewModel
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
	}
}