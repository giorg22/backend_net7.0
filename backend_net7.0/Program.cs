using Application.Commands.UserCommands;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Domain.Entities;
using Domain.IRepositories;
using Domain.IRepository;
//using Domain.IRepositories;
using Infrastructure.DB;
using Infrastructure.Repositories;
using Infrastructure.Services;
using MarketingTask.AutofacModules;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

builder.Services.AddIdentity<User, Role>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOTPService, OTPService>();

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new MediatorModule());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
