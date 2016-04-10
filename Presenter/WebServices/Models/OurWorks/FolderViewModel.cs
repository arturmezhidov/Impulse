using System.ComponentModel.DataAnnotations;

namespace WebServices.Models.OurWorks
{
	public class FolderViewModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Name { get; set; }

		[MaxLength(2048)]
		public string Description { get; set; }

		[Required]
		[MaxLength(1024)]
		public string Icon { get; set; }
	}
}