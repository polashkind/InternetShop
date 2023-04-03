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

        public void Create(UserEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<UserEntity>> GetAll(CancellationToken cancellationToken)
		{
			var result = await _dbSet.ToListAsync(cancellationToken);
			return result;
		}

		public async Task<UserEntity?> GetById(int id)
		{
			var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
			return result;
		}

        private int NextId => _dbSet.Count() == 0 ? 1 : _dbSet.Max(x => x.Id) + 1;

        public async Task<UserEntity?> PostUser(UserEntity userEntity)
		{
            userEntity.Id = NextId;
            _dbSet.Add(userEntity);

            await _context.SaveChangesAsync();
            return userEntity;
        }

        public async Task<UserEntity?> Delete(int id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
			if(result != null)
			{
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<UserEntity?> Update(UserEntity userEntity)
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == userEntity.Id);
            if (result != null)
            {
                result.FirstName = userEntity.FirstName;
                result.LastName = userEntity.LastName;
                result.Address = userEntity.Address;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

