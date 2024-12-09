﻿namespace My_Shop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Core.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    // Category will add to app with dapper
}