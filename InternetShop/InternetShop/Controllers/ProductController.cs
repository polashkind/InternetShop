using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using InternetShop.ViewModels.ProductViewModels;
using InternetShop.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var users = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.GetAll(cancellationToken));
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ProductViewModel?> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetById(id, cancellationToken);
            var mappedProduct = _mapper.Map<ProductModel>(product);
            return _mapper.Map<ProductViewModel>(mappedProduct);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<ProductViewModel>> GetByPrice([FromQuery] decimal price, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByPrice(price, cancellationToken);
            var mappedProduct = _mapper.Map<IEnumerable<ProductViewModel>>(product);
            return _mapper.Map<IEnumerable<ProductViewModel>>(mappedProduct);
        }

        [HttpPost]
        public async Task<ProductViewModel?> Post([FromBody] ChangeProductViewModel changeProductViewModel, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<ProductModel>(changeProductViewModel);
            var result = await _productService.Create(mappedProduct, cancellationToken);
            return _mapper.Map<ProductViewModel>(result);
        }

        [HttpDelete]
        public async ValueTask Delete([FromQuery] int id, CancellationToken cancellationToken)
        {
            await _productService.Delete(id, cancellationToken);
        }

        [HttpPut]
        public async Task<ProductViewModel?> Update([FromBody] ChangeProductViewModel changeProductViewModel, [FromQuery] int id, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<ProductModel>(changeProductViewModel);
            mappedProduct.Id = id;
            var result = await _productService.Update(mappedProduct, cancellationToken);
            return _mapper.Map<ProductViewModel>(result);
        }
    }
}

