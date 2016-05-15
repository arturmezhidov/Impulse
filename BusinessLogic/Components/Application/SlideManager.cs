using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impulse.BusinessLogic.BusinessContracts.Application;
using Impulse.Common.Models.Application;
using Impulse.DataAccess.DataContracts;

namespace Impulse.BusinessLogic.Components.Application
{
	public class SlideManager : DataManager<Slide>, ISlideManager
	{
		protected IUnitOfWorkApplication unitOfWork;

		public SlideManager(IUnitOfWorkApplication unitOfWork)
			: base(unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
	}
}
