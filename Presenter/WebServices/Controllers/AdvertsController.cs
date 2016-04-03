using Impulse.BusinessLogic.BusinessContracts.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServices.Controllers
{
	public class AdvertsController : ApiController
	{
		private IAdvertsManager manager;
		private bool disposed;

		public AdvertsController(IAdvertsManager manager)
		{
			this.manager = manager;
		}

		[HttpGet]
		public object Test()
		{
			int r = manager.Dislplay().Count();
			return r;
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					manager.Dispose();
				}
				disposed = true;
			}
		}
	}
}
