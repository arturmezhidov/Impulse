using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.Common.Models.Advertisements;

namespace Impulse.BusinessLogic.BusinessContracts.Advertisements
{
	public interface IAdvertsManager : IDisposable
	{
		void Add();
		IQueryable<Advert> Dislplay();
	}
}
