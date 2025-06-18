using Microsoft.ILP.ProductService.Repositories;
using Microsoft.ILP.ProductService.Services;
using Microsoft.ILP.ProductService.Mapping;
using AutoMapper;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
