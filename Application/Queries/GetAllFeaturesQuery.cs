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
    public class GetAllFeaturesQuery : IRequest<List<FeatureDto>> { }

    public class GetAllFeaturessQueryHandler : IRequestHandler<GetAllFeaturesQuery, List<FeatureDto>>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;

        public GetAllFeaturessQueryHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<FeatureDto>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<List<FeatureDto>>(users);
        }
    }
}
