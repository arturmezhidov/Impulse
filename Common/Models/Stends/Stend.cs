using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Stends
{
	[Table("Stends_Stends")]
	public class Stend : BaseItem
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

		public int MaterialId { get; set; }
		public virtual Material Material { get; set; }

		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}