using AutoMapper;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		protected readonly DatabaseContext _context;
		protected readonly DbSet<UserEntity> _dbSet;
        private readonly IMapper _mapper;

        public UserRepository(DatabaseContext context, IMapper mapper)
		{
			_context = context;
			_dbSet = _context.Set<UserEntity>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetAll(CancellationToken cancellationToken)
		{
            var userEntities = await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
            var users = _mapper.Map<List<UserModel>>(userEntities);
            return users;
        }

		public async Task<UserModel?> GetById(int id, CancellationToken cancellationToken)
		{
            var userModel = _mapper.Map<UserModel>(await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken));
            return userModel;
		}

        public async Task<UserModel?> Create(UserModel userModel, CancellationToken cancellationToken)
		{
            _dbSet.Add(_mapper.Map<UserEntity>(userModel));
            await _context.SaveChangesAsync(cancellationToken);
            return userModel;
        }

        public async Task Delete(UserModel userModel, CancellationToken cancellationToken)
        {
            _dbSet.Remove(_mapper.Map<UserEntity>(userModel));
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserModel?> Update(UserModel userModel, CancellationToken cancellationToken)
        {
            _context.Entry(_mapper.Map<UserEntity>(userModel)).State = EntityState.Modified;
			_dbSet.Update(_mapper.Map<UserEntity>(userModel));
            await _context.SaveChangesAsync(cancellationToken);
            return userModel;
        }
    }
}

