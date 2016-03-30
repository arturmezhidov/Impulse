using System;
using Impulse.Common.Models.OurWorks;

namespace Impulse.DataAccess.DataContracts
{
	public interface IUnitOfWorkOurWorks : IUnitOfWork
	{
		IRepository<Item> Items { get; }
		IRepository<Folder> Folders { get; }
	}
}