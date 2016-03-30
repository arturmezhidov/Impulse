using System;
using Impulse.Common.Models.Souvenirs;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkSouvenirs : IUnitOfWork
	{
		IRepository<Souvenir> Souvenirs { get; }
		IRepository<Category> Categories { get; }
	}
}
