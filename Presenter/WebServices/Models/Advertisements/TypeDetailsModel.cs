using System.Collections.Generic;
using WebServices.Models.Advertisements;

namespace Impulse.Presenter.WebServices.Models.Advertisements
{
	public class TypeDetailsModel : TypeViewModel
	{
		public IEnumerable<AdvertViewModel> Adverts { get; set; }

		public TypeDetailsModel()
		{
			Adverts = new List<AdvertViewModel>();
		}
	}
}