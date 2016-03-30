using System;
using Impulse.Common.Models.Tipographies;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkTipographies : IUnitOfWork
	{
		IRepository<Tipography> Tipographies { get; }
		IRepository<Kind> Kinds { get; }
	}
}
