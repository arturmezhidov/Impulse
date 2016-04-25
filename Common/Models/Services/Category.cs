using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Services
{
	[Table("Services_Categories")]
	public class Category : ISortable, IDeletable
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Icon { get; set; }

		public virtual ICollection<Service> Services { get; set; }

		public Category()
		{
			Services = new HashSet<Service>();
		}

		public int SortingNumber { get; set; }
		public bool IsDeleted { get; set; }
	}
}