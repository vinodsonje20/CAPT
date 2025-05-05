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
    public class UpdateCheckTypeCommand : IRequest<bool>
    {
        public int CheckTypeId { get; set; }
        public string CheckTypeName { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateCheckTypeCommandHandler : IRequestHandler<UpdateCheckTypeCommand, bool>
    {
        private readonly IRepository<CheckType> _repository;
        private readonly AppDbContext _context;
        private IRepository<CheckType> @object;
        private global::Moq.Mock<AppDbContext> mockContext;

        public UpdateCheckTypeCommandHandler(IRepository<CheckType> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public UpdateCheckTypeCommandHandler(IRepository<CheckType> @object, global::Moq.Mock<AppDbContext> mockContext)
        {
            this.@object = @object;
            this.mockContext = mockContext;
        }

        public async Task<bool> Handle(UpdateCheckTypeCommand request, CancellationToken cancellationToken)
        {
            var CheckType = await _repository.GetByIdAsync(request.CheckTypeId);
            if (CheckType == null) return false;
            CheckType.CheckTypeName = request.CheckTypeName;
            CheckType.RoleId = request.RoleId;
            CheckType.IsActive = request.IsActive;
            CheckType.ModifiedBy = request.UserId;
            CheckType.ModifiedDate = DateTime.Now;
            _repository.Update(CheckType);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
