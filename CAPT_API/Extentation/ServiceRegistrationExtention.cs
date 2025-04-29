using Application.Commands;
using Application.Queries;
using Application.Validators;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CAPT_API.Extentation
{
    public static class ServiceRegistrationExtention
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IRoleService, RoleService>();
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IFileService, FileService>();
            //services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IEmailSender, EmailSender>();
            //services.AddScoped<IEmailTemplate, EmailTemplate>();

            // Add FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<DeleteUserCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserCommandValidator>();

            // Add Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Add AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add MediatR
            services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
            services.AddMediatR(typeof(DeleteUserCommandHandler).Assembly);
            services.AddMediatR(typeof(UpdateUserCommandHandler).Assembly);
            services.AddMediatR(typeof(GetUserByIdQueryHandler).Assembly);
            services.AddMediatR(typeof(GetAllUsersQueryHandler).Assembly);
        }
    }
}
