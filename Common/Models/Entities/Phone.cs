using System.ComponentModel.DataAnnotations;

namespace Impulse.Common.Models.Entities
{
	public class Phone : BaseEntity
	{
		[Required]
		[MaxLength(1024)]
		public string Operator { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }

		public ContactType Type { get; set; }

		public string ProfileUserId { get; set; }
		public virtual ProfileUser ProfileUser { get; set; }
	}
}