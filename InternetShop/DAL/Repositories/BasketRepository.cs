using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class BasketRepository : GenericRepository<BasketEntity>, IBasketRepository
    {
        public BasketRepository(DatabaseContext context) : base(context)
        {
        }
    }
}

