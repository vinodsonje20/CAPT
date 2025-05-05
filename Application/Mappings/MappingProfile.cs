using Application.DTOs;
using AutoMapper;
using AutoMapper.Features;
using Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>(); // 👈 This tells AutoMapper how to map
            CreateMap<CheckType, CheckTypeDto>();
            CreateMap<Feature, FeatureDto>();
            CreateMap<Roles, RolesDto>();
        }
    }
}
