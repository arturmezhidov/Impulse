using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using Impulse.DependencyInjections.NInjectResolver;
using Impulse.DependencyInjections.NInjectResolver.BusinessModules;
using Impulse.DependencyInjections.NInjectResolver.DataModules;
using Impulse.Presenter.WebServices;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Impulse.Presenter.WebServices
{
	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServices(kernel);

				GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Load(DataModules());
			kernel.Load(BusinessModules());
		}

		static IEnumerable<INinjectModule> DataModules()
		{
			yield return new ApplicationDataModule("DbConnectionString");
			yield return new AdvertisementsDataModule("DbConnectionString");
			yield return new OurWorksDataModule("DbConnectionString");
			yield return new PhotographyDataModule("DbConnectionString");
			yield return new ServicesDataModule("DbConnectionString");
			yield return new ShopDataModule("DbConnectionString");
			yield return new SouvenirsDataModule("DbConnectionString");
			yield return new StendsDataModule("DbConnectionString");
			yield return new TipographiesDataModule("DbConnectionString");
		}
		static IEnumerable<INinjectModule> BusinessModules()
		{
			yield return new ApplicationBusinessModule();
			yield return new AdvertisementsBusinessModule();
			yield return new OurWorksBusinessModule();
			yield return new PhotographyBusinessModule();
			yield return new ServicesBusinessModule();
			yield return new ShopBusinessModule();
			yield return new SouvenirsBusinessModule();
			yield return new StendsBusinessModule();
			yield return new TipographiesBusinessModule();
		}
	}
}
