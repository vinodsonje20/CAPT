using Application.DTOs;
using AutoMapper;
using Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MasterProfile : Profile
    {
        public MasterProfile()
        {
            // BusinessType <-> MasterDto
            CreateMap<BusinessType, MasterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessTypeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.BusinessTypeName));

            CreateMap<MasterDto, BusinessType>()
                .ForMember(dest => dest.BusinessTypeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BusinessTypeName, opt => opt.MapFrom(src => src.Name));

            // CheckStatus <-> MasterDto
            CreateMap<CheckStatus, MasterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CheckStatusId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CheckStatusName));

            CreateMap<MasterDto, CheckStatus>()
                .ForMember(dest => dest.CheckStatusId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CheckStatusName, opt => opt.MapFrom(src => src.Name));
        
            // DispositionType <-> MasterDto
            CreateMap<DispositionType, MasterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DispositionTypeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DispositionTypeName));

            CreateMap<MasterDto, DispositionType>()
                .ForMember(dest => dest.DispositionTypeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DispositionTypeName, opt => opt.MapFrom(src => src.Name));

            // Location <-> MasterDto
            CreateMap<Location, MasterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LocationName));

            CreateMap<MasterDto, Location>()
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Name));

            // ServiceType <-> MasterDto
            CreateMap<ServiceType, MasterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ServiceTypeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ServiceTypeName));

            CreateMap<MasterDto, ServiceType>()
                .ForMember(dest => dest.ServiceTypeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ServiceTypeName, opt => opt.MapFrom(src => src.Name));

            // TransactionType <-> MasterDto
            CreateMap<TransactionType, MasterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TransactionTypeId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TransactionTypeName));

            CreateMap<MasterDto, TransactionType>()
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TransactionTypeName, opt => opt.MapFrom(src => src.Name));
        }
     }
}
