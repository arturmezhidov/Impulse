using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Impulse.BusinessLogic.BusinessContracts.Advertisements;

namespace WebServices.Filters
{
	public class ModelCheckAttribute : Attribute, IActionFilter
	{
		public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<System.Net.Http.HttpResponseMessage>> continuation)
		{
			var response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);

			foreach(var param in actionContext.ActionArguments)
			{
				if (param.Value == null)
				{
					return Task.FromResult(response);
				}
			}

			if (!actionContext.ModelState.IsValid)
			{
				return Task.FromResult(response);
			}

			return continuation();
		}

		public bool AllowMultiple
		{
			get { return false; }
		}
	}
}