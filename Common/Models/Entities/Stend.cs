using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class Stend : BaseEntity
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Image { get; set; }

		public int? Pockets { get; set; }

		public int? Eyelets { get; set; }

		public bool? IsBorder { get; set; }

		public int StendCategoryId { get; set; }
		public virtual StendCategory Category { get; set; }
	}
}