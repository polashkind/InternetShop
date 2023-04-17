using System;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
	public class GenericService<TModel, TEntity> : IGenericService<TModel>
        where TModel : class
        where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> _genericRepository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<TModel>>(await _genericRepository.GetAll(cancellationToken));
        }

        public async Task<TModel?> GetById(int id, CancellationToken cancellationToken)
        {
            var model = await _genericRepository.GetById(id, cancellationToken);
            var result = _mapper.Map<TModel>(model);
            return result;
        }

        public async Task<TModel?> Create(TModel model, CancellationToken cancellationToken)
        {
            var mappedModel = _mapper.Map<TEntity>(model);
            var result = await _genericRepository.Create(mappedModel, cancellationToken);
            return _mapper.Map<TModel>(result);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _genericRepository.GetById(id, cancellationToken);
            await _genericRepository.Delete(result, cancellationToken);
        }

        public async Task<TModel?> Update(TModel model, CancellationToken cancellationToken)
        {
            var mappedModel = _mapper.Map<TEntity>(model);
            var result = await _genericRepository.Update(mappedModel, cancellationToken);
            return _mapper.Map<TModel>(result);
        }
    }
}

