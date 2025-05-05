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
    public class UpdateMasterCommand<TEntity> : IRequest<bool>
    where TEntity : class, IMasterEntity, new()
    {
        public MasterDto Dto { get; }

        public UpdateMasterCommand(MasterDto dto)
        {
            Dto = dto;
        }
    }

    public class UpdateMasterCommandHandler<TEntity> : IRequestHandler<UpdateMasterCommand<TEntity>, bool>
     where TEntity : class, IMasterEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public UpdateMasterCommandHandler(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMasterCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Dto.Id);
            if (entity == null)
                throw new KeyNotFoundException("Entity not found");

            _mapper.Map(request.Dto, entity);
            entity.ModifiedDate = DateTime.UtcNow;
            
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
