using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Shop.Application.Services;
using My_Shop.Infrastructure;
using My_Shop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// add db context to program class
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//add customer service
builder.Services.AddScoped<ICustomerService, CustomerService>();
//add product service
builder.Services.AddScoped<IProductService, ProductService>();
//add order service
builder.Services.AddScoped<IOrderService, OrderService>();
//add category service
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
