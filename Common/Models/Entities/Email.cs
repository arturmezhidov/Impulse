using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class Email : BaseEntity
	{
		[Required]
		[MaxLength(1024)]
		public string Address { get; set; }

		public ContactType Type { get; set; }

		public string ProfileUserId { get; set; }
		public virtual ProfileUser ProfileUser { get; set; }
	}
}