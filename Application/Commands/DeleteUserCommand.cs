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
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IRepository<User> _repository;
        private readonly AppDbContext _context;

        public DeleteUserCommandHandler(IRepository<User> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null) return false;
            _repository.Delete(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

}
