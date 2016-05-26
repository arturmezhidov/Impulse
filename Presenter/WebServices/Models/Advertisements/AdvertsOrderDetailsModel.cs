using System;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class AdvertsOrderDetailsModel
	{
		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApproveDate { get; set; }

		public int Count { get; set; }

		public double Width { get; set; }

		public double Height { get; set; }

		public virtual AdvertViewModel Advert { get; set; }
	}
}