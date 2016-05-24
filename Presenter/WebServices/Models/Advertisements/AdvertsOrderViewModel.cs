using System;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class AdvertsOrderViewModel
	{
		public string Name { get; set; }
		public string Contacts { get; set; }
		public string Description { get; set; }
		public int Count { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }

		public int AdvertId { get; set; }
	}
}