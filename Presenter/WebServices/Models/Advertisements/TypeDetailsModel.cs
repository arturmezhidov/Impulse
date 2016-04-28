using System.Collections.Generic;

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