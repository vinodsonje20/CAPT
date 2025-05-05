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
    public class CreateCheckTypeCommand : IRequest<int>
    {
        public string CheckTypeName { get; set; } = string.Empty;        
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }

    public class CreateCheckTypeCommandHandler : IRequestHandler<CreateCheckTypeCommand, int>
    {
        private readonly IRepository<CheckType> _repository;
        private readonly AppDbContext _context;

        public CreateCheckTypeCommandHandler(IRepository<CheckType> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<int> Handle(CreateCheckTypeCommand request, CancellationToken cancellationToken)
        {
            var CheckType = new CheckType { CheckTypeName = request.CheckTypeName, RoleId = request.RoleId, IsActive = request.IsActive, CreatedBy = request.UserId,CreatedDate = DateTime.Now};
            await _repository.AddAsync(CheckType);
            await _context.SaveChangesAsync(cancellationToken);
            return CheckType.CheckTypeId;
        }
    }
}
