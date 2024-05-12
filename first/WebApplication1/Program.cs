using WebApplication1.Services.Impls;
using WebApplication1.Services;
using WebApplication1.Generators.Impl;
using WebApplication1.Generators;
using WebApplication1.Middlewave;
using Microsoft.AspNetCore.Diagnostics;
using WebApplication1.src.Utils.Impls;
using WebApplication1.src.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICoffeeService, CoffeeServiceImpl>();
builder.Services.AddSingleton<ICoffeeResponseGenerator, CoffeeResponseGeneratorImpl>();
builder.Services.AddSingleton<ISystemTime, SystemTime>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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
