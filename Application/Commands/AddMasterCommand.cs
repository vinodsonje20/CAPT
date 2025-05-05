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

namespace Application.Commands
{
    public class AddMasterCommand<TDto, TEntity> : IRequest<int>
     where TEntity : class, IMasterEntity, new()
    {
        public TDto Dto { get; }

        public AddMasterCommand(TDto dto)
        {
            Dto = dto;
        }
    }

    public class AddMasterCommandHandler<TDto, TEntity> : IRequestHandler<AddMasterCommand<TDto, TEntity>, int>
    where TEntity : class, IMasterEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public AddMasterCommandHandler(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddMasterCommand<TDto, TEntity> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request.Dto);
            entity.CreatedDate = DateTime.UtcNow;

            await _repository.AddAsync(entity);
            return entity.GetId(); // Uses interface method
        }
    }
}
