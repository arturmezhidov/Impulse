using System.ComponentModel.DataAnnotations;

namespace WebServices.Models.Contacts
{
	public class EmailViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Address { get; set; }
	}
}