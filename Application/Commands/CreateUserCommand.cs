using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IRepository<User> _repository;
        private readonly AppDbContext _context;

        public CreateUserCommandHandler(IRepository<User> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Name = request.Name, Email = request.Email };
            await _repository.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
