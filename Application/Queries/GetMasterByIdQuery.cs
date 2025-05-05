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
    public class GetMasterByIdQuery<TEntity> : IRequest<MasterDto>
    where TEntity : class, IMasterEntity, new()
    {
        public int Id { get; }

        public GetMasterByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetMasterByIdQueryHandler<TEntity> : IRequestHandler<GetMasterByIdQuery<TEntity>, MasterDto>
    where TEntity : class, IMasterEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GetMasterByIdQueryHandler(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MasterDto> Handle(GetMasterByIdQuery<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new KeyNotFoundException("Entity not found");

            return _mapper.Map<MasterDto>(entity);
        }
    }
}
