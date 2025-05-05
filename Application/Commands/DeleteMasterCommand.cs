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
    public class DeleteMasterCommand<TEntity> : IRequest<bool>
     where TEntity : class, IMasterEntity, new()
    {
        public int Id { get; }

        public DeleteMasterCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteMasterCommandHandler<TEntity> : IRequestHandler<DeleteMasterCommand<TEntity>, bool>
    where TEntity : class, IMasterEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;

        public DeleteMasterCommandHandler(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteMasterCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new KeyNotFoundException("Entity not found");

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
