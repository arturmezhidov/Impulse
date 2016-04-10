using System.ComponentModel.DataAnnotations;

namespace WebServices.Models.Stends
{
	public class MaterialViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }
	}
}