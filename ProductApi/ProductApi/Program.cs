using Microsoft.EntityFrameworkCore;
using ProductApi.Data_Access;
using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericEfCoreRepository<>));

builder.Services.AddAutoMapper(typeof(ProductProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext with an in-memory database
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddScoped<IProductDbContext>(provider =>
    provider.GetRequiredService<ProductDbContext>());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    SeedData.Initialize(dbContext);
}


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

// For testing:
public partial class Program { }