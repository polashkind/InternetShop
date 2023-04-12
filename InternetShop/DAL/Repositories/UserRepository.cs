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
            var userEntities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
            return userEntities;
        }

		public async Task<UserEntity?> GetById(int id, CancellationToken cancellationToken)
		{
            var userModel = await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
            return userModel;
		}

        public async Task<UserEntity?> Create(UserEntity userEntity, CancellationToken cancellationToken)
		{
            _dbSet.Add(userEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return userEntity;
        }

        public async Task Delete(UserEntity userEntity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(userEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserEntity> Update(UserEntity userEntity, CancellationToken cancellationToken)
        {
            _context.Entry(userEntity).State = EntityState.Modified;
			_dbSet.Update(userEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return userEntity;
        }
    }
}

