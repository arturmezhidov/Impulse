using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Impulse.Presenter.WebServices.Filters
{
	public class ModelCheckAttribute : Attribute, IActionFilter
	{
		public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<System.Net.Http.HttpResponseMessage>> continuation)
		{
			if (!actionContext.ModelState.IsValid)
			{
				return Task.FromResult(actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState));
			}

			foreach(var param in actionContext.ActionArguments)
			{
				if (param.Value == null)
				{
					return Task.FromResult(actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState));
				}
			}

			return continuation();
		}

		public bool AllowMultiple
		{
			get { return false; }
		}
	}
}