using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Application
{
	[Table("Phones")]
	public class Phone : BaseItem
	{
		[Required]
		[MaxLength(1024)]
		public string Operator { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }
	}
}