using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Impulse.Common.Components.Loggers;

namespace Impulse.Presenter.WebServices.Filters
{
	public class ExceptionLoggerAttribute : ExceptionFilterAttribute
	{
		public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
		{
			FileLogger.Error(actionExecutedContext.Exception);

			var response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, actionExecutedContext.Exception);

			return Task.FromResult(response);
		}
	}
}