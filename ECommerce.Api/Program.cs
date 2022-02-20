using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using ECommerce.Application.DependencyResolvers.Autofac;
using ECommerce.Api.Filters;
using FluentValidation.AspNetCore;
using ECommerce.Business.Validation;

var builder = WebApplication.CreateBuilder(args);

// HealtCheck
builder.Services.AddHealthChecks();

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

// Add services to the container.
builder.Services.AddControllers(config => config.Filters.Add(typeof(ValidateModelAttribute)))
            .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<IValidationsMarker>());

// InMemory Sql
builder.Services.AddDbContext<ECommerceDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health");

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
