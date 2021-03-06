﻿using System.Web.Http;
using Impulse.Presenter.WebServices.Formatters;
using Microsoft.Owin.Security.OAuth;

namespace Impulse.Presenter.WebServices
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Конфигурация и службы веб-API
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			// Маршруты веб-API
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.Add(new FileModelFormatter());
		}
	}
}
