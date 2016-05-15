using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Application
{
	[Table("Emails")]
	public class Email : BaseItem
	{
		[Required]
		[MaxLength(1024)]
		public string Address { get; set; }
	}
}
