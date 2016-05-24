using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class Social : BaseEntity
	{
		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Url { get; set; }

		public ContactType Type { get; set; }

		public string ProfileUserId { get; set; }
		public virtual ProfileUser ProfileUser { get; set; }
	}
}