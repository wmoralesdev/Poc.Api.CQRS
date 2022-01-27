using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Poc.Api.Core.Extensions;
using Poc.Api.Domain.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.Load("Poc.Api.Application"));

builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseNpgsql((
            Environment.GetEnvironmentVariable("DATABASE_URL") ??
            builder.Configuration.GetConnectionString("PocDb")
        )
        .BuildConnectionString(),
        b => b.MigrationsAssembly("Poc.Api.Application")
    )
);

builder.Services.AddAutoMapper(Assembly.Load("Poc.Api.Application"));

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();