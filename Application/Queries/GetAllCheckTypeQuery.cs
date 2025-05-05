using Application.DTOs;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllCheckTypeQuery : IRequest<List<CheckTypeDto>> { }

    public class GetAllCheckTypeQueryHandler : IRequestHandler<GetAllCheckTypeQuery, List<CheckTypeDto>>
    {
        private readonly IRepository<CheckType> _repository;
        private readonly IMapper _mapper;

        public GetAllCheckTypeQueryHandler(IRepository<CheckType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CheckTypeDto>> Handle(GetAllCheckTypeQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<List<CheckTypeDto>>(users);
        }
    }
}
