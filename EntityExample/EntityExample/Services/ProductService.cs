using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityExample.Data;
using EntityExample.Data.Entities;
using EntityExample.Mappers;
using EntityExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityExample.Services;

public class ProductService
{
    private readonly AppBeaverContext _context;
    private readonly MapperConfiguration _config;
    public ProductService(AppBeaverContext context)
    {
        _context = context;
        _config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>(); // Додаємо профіль мапінгу
        });
    }
    /// <summary>
    /// Отримати всі продукти
    /// </summary>
    /// <returns>Список продуктів</returns>
    public async Task<List<ProductEntity>> GetAllProductsAsync()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

    public async Task<List<ProductItemModel>> GetCountProductsAsync(int count)
    {
        // query це IQueryable, який дозволяє виконувати запити до бази даних
        // з використанням методів LINQ, таких як Skip і Take для пагінації
        // Використання Include для завантаження пов'язаних даних (категорій)
        var query = _context.Products
            //.Include(p => p.Category)
            .AsQueryable();
        query = query.Skip(0).Take(count); // Можна використовувати для пагінації
        var list = await query
            .ProjectTo<ProductItemModel>(_config)
            //.Select(p => new ProductItemModel
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Price = p.Price,
            //    CategoryName = p.Category.Name
            //})
            .ToListAsync();
        return list;
    }
    /// <summary>
    /// Додати новий продукт
    /// </summary>
    /// <param name="product">Продукт для додавання</param>
    public async Task AddProductAsync(ProductEntity product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task SeedFakeProducts()
    {
        if (!_context.Products.Any())
        {
            var faker = new Bogus.Faker("uk");
            // Генерація фейкових продуктів
            var categoryIds = await _context.Categories
                .Skip(0) // Можна використовувати для пагінації
                .Take(10) // Обмеження на кількість категорій для генерації продуктів
                .Select(c=>c.Id)
                .ToListAsync();
            foreach (var categoryId in categoryIds)
            {
                for (int i = 0; i < 10; i++)
                {
                    var product = new ProductEntity
                    {
                        Name = faker.Commerce.ProductName(),
                        Price = decimal.Parse(faker.Commerce.Price(10, 1000)),
                        CategoryId = categoryId
                    };
                    _context.Products.Add(product);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
