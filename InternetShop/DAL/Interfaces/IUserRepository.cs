using System;
using System.Threading;
using DAL.Entities;

namespace DAL.Interfaces
{
	public interface IUserRepository
	{
        Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken);
    }
}

