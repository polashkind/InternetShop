using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class BasketService : GenericService<BasketModel, BasketEntity>, IBasketService
    {
        protected readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository, IMapper mapper) : base(basketRepository, mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasketModel>> GetAll(CancellationToken cancellationToken)
        {
            var baskets = _mapper.Map<IEnumerable<BasketModel>>(await _basketRepository.GetAll(cancellationToken));
            var totalBasketprice = TotalBasketPrice(baskets);
            return totalBasketprice;
        }

        private IEnumerable<BasketModel> TotalBasketPrice(IEnumerable<BasketModel> baskets)
        {
            foreach (var basket in baskets)
            {
                basket.TotalBasketPrice = basket.Count * basket.Price;
            }

            return baskets;
        }
    }
}

