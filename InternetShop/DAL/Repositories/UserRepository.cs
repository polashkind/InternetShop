using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>,  IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}

