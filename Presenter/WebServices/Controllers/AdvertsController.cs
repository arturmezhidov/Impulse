using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Impulse.Common.Models.Advertisements;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;

namespace WebServices.Controllers
{
	[RoutePrefix("api/advertisements")]
	public class AdvertsController : ApiController
	{
		private IAdvertsManager manager;
		private bool disposed;

		public AdvertsController(IAdvertsManager manager)
		{
			this.manager = manager;
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

		[HttpGet]
		[Route("adverts")]
		public string Adverts()
		{
			return "all adverts";
		}
		[HttpGet]
		[Route("adverts/{id}")]
		public string Adverts(int id)
		{
			return "advert: " + id;
		}

		[HttpGet]
		[Route("types")]
		public string Types()
		{
			return "all types";
		}
		[HttpGet]
		[Route("types/{id}")]
		public string Types(int id)
		{
			return "type: " + id;
		}
	}
}
