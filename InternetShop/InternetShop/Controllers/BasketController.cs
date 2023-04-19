using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using InternetShop.ViewModels.BasketViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BasketViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var baskets = _mapper.Map<IEnumerable<BasketViewModel>>(await _basketService.GetAll(cancellationToken));
            return baskets;
        }

        [HttpGet("{id}")]
        public async Task<BasketViewModel?> GetById(int id, CancellationToken cancellationToken)
        {
            var basket = await _basketService.GetById(id, cancellationToken);
            var mappedBasket = _mapper.Map<BasketModel>(basket);
            return _mapper.Map<BasketViewModel>(mappedBasket);
        }

        [HttpPost]
        public async Task<BasketViewModel?> Post([FromBody] ChangeBasketViewModel changeBasketViewModel, CancellationToken cancellationToken)
        {
            var mappedBasket = _mapper.Map<BasketModel>(changeBasketViewModel);
            var result = await _basketService.Create(mappedBasket, cancellationToken);
            return _mapper.Map<BasketViewModel>(result);
        }

        [HttpDelete("{id}")]
        public async ValueTask Delete([FromQuery] int id, CancellationToken cancellationToken)
        {
            await _basketService.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<BasketViewModel?> Update([FromBody] ChangeBasketViewModel changeBasketViewModel, [FromQuery] int id, CancellationToken cancellationToken)
        {
            var mappedBasket = _mapper.Map<BasketModel>(changeBasketViewModel);
            mappedBasket.Id = id;
            var result = await _basketService.Update(mappedBasket, cancellationToken);
            return _mapper.Map<BasketViewModel>(result);
        }
    }
}

