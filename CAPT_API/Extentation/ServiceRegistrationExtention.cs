using Application.Commands;
using Application.DTOs;
using Application.Mappings;
using Application.Queries;
using Application.Validators;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CAPT_API.Extentation
{
    public static class ServiceRegistrationExtention
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            // Add FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<DeleteUserCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCheckTypeCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<DeleteCheckTypeCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCheckTypeCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<MasterDtoValidator>();

            // Add Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Add AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add MediatR 
            // User Master
            services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteUserCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateUserCommandHandler).Assembly);
            services.AddMediatR(typeof(GetUserByIdQueryHandler).Assembly);
            services.AddMediatR(typeof(GetAllUsersQueryHandler).Assembly);
            // CheckType
            services.AddMediatR(typeof(CreateCheckTypeCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteCheckTypeCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateCheckTypeCommandHandler).Assembly);
            services.AddMediatR(typeof(GetCheckTypeByIdQueryHandler).Assembly);
            services.AddMediatR(typeof(GetAllCheckTypeQueryHandler).Assembly);

            // Master Table - BusinessType, CheckStatus, DispositionType, Location, ServiceType, TransactionType
            services.AddTransient(typeof(IRequestHandler<GetAllMastersQuery<BusinessType>, List<MasterDto>>), typeof(GetAllMastersQueryHandler<BusinessType>));
            services.AddTransient(typeof(IRequestHandler<GetAllMastersQuery<CheckStatus>, List<MasterDto>>), typeof(GetAllMastersQueryHandler<CheckStatus>));
            services.AddTransient(typeof(IRequestHandler<GetAllMastersQuery<DispositionType>, List<MasterDto>>), typeof(GetAllMastersQueryHandler<DispositionType>));
            services.AddTransient(typeof(IRequestHandler<GetAllMastersQuery<Location>, List<MasterDto>>), typeof(GetAllMastersQueryHandler<Location>));
            services.AddTransient(typeof(IRequestHandler<GetAllMastersQuery<ServiceType>, List<MasterDto>>), typeof(GetAllMastersQueryHandler<ServiceType>));
            services.AddTransient(typeof(IRequestHandler<GetAllMastersQuery<TransactionType>, List<MasterDto>>), typeof(GetAllMastersQueryHandler<TransactionType>));

            services.AddTransient<IRequestHandler<GetMasterByIdQuery<BusinessType>, MasterDto>, GetMasterByIdQueryHandler<BusinessType>>();
            services.AddTransient<IRequestHandler<GetMasterByIdQuery<CheckStatus>, MasterDto>, GetMasterByIdQueryHandler<CheckStatus>>();
            services.AddTransient<IRequestHandler<GetMasterByIdQuery<DispositionType>, MasterDto>, GetMasterByIdQueryHandler<DispositionType>>();
            services.AddTransient<IRequestHandler<GetMasterByIdQuery<Location>, MasterDto>, GetMasterByIdQueryHandler<Location>>();
            services.AddTransient<IRequestHandler<GetMasterByIdQuery<ServiceType>, MasterDto>, GetMasterByIdQueryHandler<ServiceType>>();
            services.AddTransient<IRequestHandler<GetMasterByIdQuery<TransactionType>, MasterDto>, GetMasterByIdQueryHandler<TransactionType>>();

            services.AddTransient<IRequestHandler<AddMasterCommand<MasterDto, BusinessType>, int>, AddMasterCommandHandler<MasterDto, BusinessType>>();
            services.AddTransient<IRequestHandler<AddMasterCommand<MasterDto, CheckStatus>, int>, AddMasterCommandHandler<MasterDto, CheckStatus>>();
            services.AddTransient<IRequestHandler<AddMasterCommand<MasterDto, DispositionType>, int>, AddMasterCommandHandler<MasterDto, DispositionType>>();
            services.AddTransient<IRequestHandler<AddMasterCommand<MasterDto, Location>, int>, AddMasterCommandHandler<MasterDto, Location>>();
            services.AddTransient<IRequestHandler<AddMasterCommand<MasterDto, ServiceType>, int>, AddMasterCommandHandler < MasterDto, ServiceType>> ();
            services.AddTransient<IRequestHandler<AddMasterCommand<MasterDto, TransactionType>, int>, AddMasterCommandHandler<MasterDto, TransactionType>>();

            services.AddTransient<IRequestHandler<UpdateMasterCommand<BusinessType>, bool>, UpdateMasterCommandHandler<BusinessType>>();
            services.AddTransient<IRequestHandler<UpdateMasterCommand<CheckStatus>, bool>, UpdateMasterCommandHandler<CheckStatus>>();
            services.AddTransient<IRequestHandler<UpdateMasterCommand<DispositionType>, bool>, UpdateMasterCommandHandler<DispositionType>>();
            services.AddTransient<IRequestHandler<UpdateMasterCommand<Location>, bool>, UpdateMasterCommandHandler<Location>>();
            services.AddTransient<IRequestHandler<UpdateMasterCommand<ServiceType>, bool>, UpdateMasterCommandHandler<ServiceType>>();
            services.AddTransient<IRequestHandler<UpdateMasterCommand<TransactionType>, bool>, UpdateMasterCommandHandler<TransactionType>>();

            services.AddTransient<IRequestHandler<DeleteMasterCommand<BusinessType>, bool>, DeleteMasterCommandHandler<BusinessType>>();
            services.AddTransient<IRequestHandler<DeleteMasterCommand<CheckStatus>, bool>, DeleteMasterCommandHandler<CheckStatus>>();
            services.AddTransient<IRequestHandler<DeleteMasterCommand<DispositionType>, bool>, DeleteMasterCommandHandler<DispositionType>>();
            services.AddTransient<IRequestHandler<DeleteMasterCommand<Location>, bool>, DeleteMasterCommandHandler<Location>>();
            services.AddTransient<IRequestHandler<DeleteMasterCommand<ServiceType>, bool>, DeleteMasterCommandHandler<ServiceType>>();
            services.AddTransient<IRequestHandler<DeleteMasterCommand<TransactionType>, bool>, DeleteMasterCommandHandler<TransactionType>>();
        }
    }
}
