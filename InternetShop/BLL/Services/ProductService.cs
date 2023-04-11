using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
	public class ProductService : IProductService
	{
        protected readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductModel>> GetAll(CancellationToken cancellationToken)
        {
            var users = _mapper.Map<IEnumerable<ProductModel>>(await _productRepository.GetAll(cancellationToken));
            return users;
        }

        public async Task<ProductModel?> GetById(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(id, cancellationToken);
            var mappedProduct = _mapper.Map<ProductModel>(product);
            return mappedProduct;
        }


        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(id, cancellationToken);
            await _productRepository.Delete(product, cancellationToken);
        }

        public async Task<ProductModel?> Update(ProductModel productModel, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<ProductEntity>(productModel);
            var result = await _productRepository.Update(mappedProduct, cancellationToken);
            return _mapper.Map<ProductModel>(result);
        }
    }
}

