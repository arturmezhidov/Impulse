using System;
using Impulse.Common.Models.Souvenirs;

namespace Impulse.DataAccess.Contracts
{
	public partial interface IUnitOfWork
	{
		IRepository<Souvenir> Souvenirs { get; }
		IRepository<SouvenirsCategory> SouvenirsCategories { get; set; }
	}
}
