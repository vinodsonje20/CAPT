using Application.Commands;
using Application.Validators;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using CAPT_API.Extentation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Builder;
using Application.Services.Email;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Negotiate")
    .AddNegotiate();

// Set up NLog
NLog.LogManager.Setup().LoadConfigurationFromFile("NLog.config");

// Add NLog to the logging pipeline
builder.Logging.ClearProviders();
builder.Logging.AddNLog();

// Add Controllers
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Services Extentation Method To Register All Services 
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("Email"));
builder.Services.AddServiceRegistration();

// Add CORS service
builder.Services.AddCors(options =>
{
    // Define CORS policies here
    options.AddPolicy("CAPTPolicy", policy =>
    {
        policy.WithOrigins("http://capt.starda.com", "*") // Allow specific origins
               .WithMethods("GET", "POST","PUT","DELETE")  // Allow specific methods
               .WithHeaders("Content-Type"); // Allow specific headers
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CAPT API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // ✅ important
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CAPT API V1");
        // Optional: serve swagger UI at root (localhost:7044)
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
