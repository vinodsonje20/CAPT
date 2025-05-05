using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteCheckTypeCommand : IRequest<bool>
    {
        public int CheckTypeId { get; set; }
    }

    public class DeleteCheckTypeCommandHandler : IRequestHandler<DeleteCheckTypeCommand, bool>
    {
        private readonly IRepository<CheckType> _repository;
        private readonly AppDbContext _context;

        public DeleteCheckTypeCommandHandler(IRepository<CheckType> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<bool> Handle(DeleteCheckTypeCommand request, CancellationToken cancellationToken)
        {
            var CheckType = await _repository.GetByIdAsync(request.CheckTypeId);
            if (CheckType == null) return false;
            _repository.Delete(CheckType);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

}
