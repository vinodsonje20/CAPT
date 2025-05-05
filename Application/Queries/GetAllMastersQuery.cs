using Application.DTOs;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Data.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllMastersQuery<TEntity> : IRequest<List<MasterDto>>
    where TEntity : class, IMasterEntity, new()
    {
    }
    public class GetAllMastersQueryHandler<TEntity> : IRequestHandler<GetAllMastersQuery<TEntity>, List<MasterDto>>
    where TEntity : class, IMasterEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GetAllMastersQueryHandler(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MasterDto>> Handle(GetAllMastersQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterDto>>(entities);
        }
    }
}
