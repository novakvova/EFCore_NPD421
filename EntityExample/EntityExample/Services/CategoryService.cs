using Bogus;
using EntityExample.Data;
using EntityExample.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityExample.Services;

public class CategoryService
{
    private readonly AppBeaverContext _context;
    public CategoryService(AppBeaverContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Отримати всі категорії
    /// </summary>
    /// <returns>Список категорій</returns>
    public async Task<List<CategoryEntity>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    /// <summary>
    /// Додати нову категорію
    /// </summary>
    /// <param name="category">Категорія для додавання</param>
    public async Task AddCategoryAsync(CategoryEntity category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task SeedFakeCategories()
    {
        if (!_context.Categories.Any())
        {
            var faker = new Faker("uk");
            // Генерація фейкових категорій
            var list = faker.Commerce.Categories(10);
            foreach (var categoryName in list)
            {
                var category = new CategoryEntity
                {
                    Name = categoryName
                };
                _context.Categories.Add(category);
            }
            await _context.SaveChangesAsync();
        }
    }
}
