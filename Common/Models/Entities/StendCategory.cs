using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class StendCategory : BaseEntity, ISortable
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Icon { get; set; }

		public int SortingNumber { get; set; }

		public virtual ICollection<Stend> Stends { get; set; }

		public StendCategory()
		{
			Stends = new HashSet<Stend>();
		}
	}
}