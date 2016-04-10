using System.ComponentModel.DataAnnotations;

namespace WebServices.Models.Contacts
{
	public class PhoneViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Operator { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Number { get; set; }
	}
}