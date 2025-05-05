using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Data.Models;

namespace Application.Queries
{
    public class GetCheckTypeByIdQuery : IRequest<CheckTypeDto>
    {
        public int CheckTypeId { get; set; }
    }
    public class GetCheckTypeByIdQueryHandler : IRequestHandler<GetCheckTypeByIdQuery, CheckTypeDto>
    {
        private readonly IRepository<CheckType> _repository;
        private readonly IMapper _mapper;

        public GetCheckTypeByIdQueryHandler(IRepository<CheckType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CheckTypeDto> Handle(GetCheckTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.CheckTypeId);
            return _mapper.Map<CheckTypeDto>(user);
        }
    }
}
