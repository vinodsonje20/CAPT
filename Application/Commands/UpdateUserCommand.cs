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
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IRepository<User> _repository;
        private readonly AppDbContext _context;
        private IRepository<User> @object;
        private global::Moq.Mock<AppDbContext> mockContext;

        public UpdateUserCommandHandler(IRepository<User> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public UpdateUserCommandHandler(IRepository<User> @object, global::Moq.Mock<AppDbContext> mockContext)
        {
            this.@object = @object;
            this.mockContext = mockContext;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null) return false;

            user.Name = request.Name;
            user.Email = request.Email;

            _repository.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
