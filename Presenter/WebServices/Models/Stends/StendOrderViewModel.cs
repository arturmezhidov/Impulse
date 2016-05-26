using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Stends
{
	public class StendOrderViewModel
	{
		[MaxLength(2048)]
		public string Description { get; set; }

		public int Count { get; set; }

		public int StendId { get; set; }
	}
}