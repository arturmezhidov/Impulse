using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class Slide : BaseEntity
	{
		[MaxLength(1024)]
		[Required]
		public string Image { get; set; }

		[MaxLength(1024)]
		public string Url { get; set; }

		[MaxLength(4096)]
		public string About { get; set; }
	}
}