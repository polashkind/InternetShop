using System;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		protected readonly DatabaseContext _context;
		protected readonly DbSet<UserEntity> _dbSet;

		public UserRepository(DatabaseContext context)
		{
			_context = context;
			_dbSet = _context.Set<UserEntity>();
		}

		public async Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken)
		{
			var result = await _dbSet.ToListAsync(cancellationToken);
			return result;
		}
    }
}

