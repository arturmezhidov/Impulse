using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class PhotoService : BaseEntity, ISortable
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Image { get; set; }

		public int SortingNumber { get; set; }
	}
}