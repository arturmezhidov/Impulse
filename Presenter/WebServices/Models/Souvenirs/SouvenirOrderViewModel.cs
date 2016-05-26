using System.ComponentModel.DataAnnotations;

namespace Impulse.Presenter.WebServices.Models.Souvenirs
{
	public class SouvenirOrderViewModel
	{
		[MaxLength(2048)]
		public string Description { get; set; }

		public int Count { get; set; }

		public int SouvenirdId { get; set; }
	}
}