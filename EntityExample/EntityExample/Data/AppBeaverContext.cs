﻿using EntityExample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EntityExample.Data;

public class AppBeaverContext : DbContext
{
    public AppBeaverContext()
    {

    }

    /// <summary>
    /// Конструктор для DI (Dependency Injection)
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conf = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connStr = conf["ConnectionStrings:DefaultConnection"];
        // Підключення до бази даних
        optionsBuilder.UseNpgsql(connStr)
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    /// <summary>
    /// Таблиця в БД
    /// </summary>
    public DbSet<UserEntity> Users { get; set; }

    /// <summary>
    /// Список категорій
    /// </summary>
    public DbSet<CategoryEntity> Categories { get; set; }

    /// <summary>
    /// Список продуктів
    /// </summary>
    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<OrderStatusEntity> OrderStatuses { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }

}
