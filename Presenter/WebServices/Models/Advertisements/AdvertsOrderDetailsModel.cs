using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class AdvertsOrderDetailsModel
	{
		public string Name { get; set; }
		public string Contacts { get; set; }
		public string Description { get; set; }
		public bool IsApprove { get; set; }
		public bool IsUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public int Count { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }
	}
}