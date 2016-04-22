using System.ComponentModel.DataAnnotations.Schema;

namespace Impulse.Common.Models.Application
{
	[Table("ProfilesUsers")]
	public class ProfileUser
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
