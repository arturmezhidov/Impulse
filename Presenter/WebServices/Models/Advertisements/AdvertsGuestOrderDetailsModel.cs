using System;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class AdvertsGuestOrderDetailsModel
	{
		public string Name { get; set; }

		public string Contacts { get; set; }

		public string Description { get; set; }

		public bool IsApprove { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ApproveDate { get; set; }

		public int Count { get; set; }

		public double Width { get; set; }

		public double Height { get; set; }

		public AdvertViewModel Advert { get; set; }
	}
}