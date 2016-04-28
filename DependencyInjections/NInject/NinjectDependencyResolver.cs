﻿using Ninject;
using System.Web.Http.Dependencies;

namespace Impulse.DependencyInjections.NInjectResolver
{
	public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
	{
		IKernel kernel;

		public NinjectDependencyResolver(IKernel kernel)
			: base(kernel)
		{
			this.kernel = kernel;
		}

		public IDependencyScope BeginScope()
		{
			return new NinjectDependencyScope(kernel.BeginBlock());
		}
	}
}
