using EntityExample.Data;
using EntityExample.Data.Entities;

namespace EntityExample.Services;

public class OrderService
{
    AppBeaverContext _context;
    public OrderService(AppBeaverContext context)
    {
        _context = context;
    }

    public async Task SeedStatuses()
    {
        if (!_context.OrderStatuses.Any())
        {
            List<string> names = new List<string>() {
                "Нове", "Очікує оплати", "Оплачено",
                "В обробці", "Готується до відправки",
                "Відправлено", "У дорозі", "Доставлено",
                "Завершено", "Скасовано (вручну)", "Скасовано (автоматично)",
                "Повернення", "В обробці повернення" };

            var orderStatuses = names.Select(name => new OrderStatusEntity { Name = name }).ToList();

            await _context.OrderStatuses.AddRangeAsync(orderStatuses);
            await _context.SaveChangesAsync();
        }
    }

}
