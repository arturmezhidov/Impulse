using System;

namespace Impulse.Presenter.WebServices.Models.Souvenirs
{
	public class SouvenirOrderDetailsModel
	{
		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApproveDate { get; set; }

		public int Count { get; set; }

		public virtual SouvenirViewModel Souvenir { get; set; }
	}
}