using System.Collections.Generic;
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
            var products = _mapper.Map<IEnumerable<ProductModel>>(await _productRepository.GetAll(cancellationToken));
            var productsWithDiscount = PriceWithDiscount(products);
            return productsWithDiscount;
        }

        private IEnumerable<ProductModel> PriceWithDiscount(IEnumerable<ProductModel> products)
        {
            foreach (var product in products)
            {
                product.PriceWithDiscount = product.Price - (product.Price * product.Discount) / 100;
            }

            return products;
        }

        public async Task<ProductModel?> GetById(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(id, cancellationToken);
            var mappedProduct = _mapper.Map<ProductModel>(product);
            return mappedProduct;
        }

        public async Task<IEnumerable<ProductModel>> GetByPrice(decimal price, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByPrice(price, cancellationToken);
            var mappedProduct = _mapper.Map<IEnumerable<ProductModel>>(product);
            return mappedProduct;
        }

        public async Task<ProductModel?> Create(ProductModel productModel, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<ProductEntity>(productModel);
            var result = await _productRepository.Create(mappedProduct, cancellationToken);
            return _mapper.Map<ProductModel>(result);
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

