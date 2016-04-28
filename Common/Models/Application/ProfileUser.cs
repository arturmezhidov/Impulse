using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Application
{
	[Table("ProfilesUsers")]
	public class ProfileUser : BaseItem
	{
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(1024)]
		public string Surname { get; set; }
	}
}
