using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class Souvenir : BaseEntity
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

		public int SouvenirCategoryId { get; set; }
		public virtual SouvenirCategory Category { get; set; }
	}
}