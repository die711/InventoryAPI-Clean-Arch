using FluentValidation;
using Inventory.Application.DTOs.Category;
using Inventory.Application.Interfaces;
using Inventory.Application.Services;
using Inventory.Application.Validators.Category;
using Inventory.Domain.Interfaces;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();

builder.Services.AddMapster();
TypeAdapterConfig.GlobalSettings.Scan(typeof(CategoryResultDto).Assembly);



builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();