using Microsoft.EntityFrameworkCore;
using MyShop.Application.Interfaces;
using MyShop.Application.Services;
using MyShop.Infrastructure.Data;
using MyShop.Core.Interfaces;
using MyShop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// اضافه کردن DbContext برای EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// اضافه کردن Dapper و CategoryRepository
builder.Services.AddSingleton<DapperDbConnection>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// اضافه کردن بقیه Repository ها
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
// سرویس ها
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();