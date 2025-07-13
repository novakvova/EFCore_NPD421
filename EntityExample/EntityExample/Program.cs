using EntityExample.Data;
using EntityExample.Data.Entities;
using Bogus;
using System.Globalization;
using EntityExample.Models;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

int action = 0;
do
{
    Console.WriteLine("Виберіть дію:");
    Console.WriteLine("0. Вийти");
    Console.WriteLine("1. Додати рандом користувачів");
    Console.WriteLine("2. Вивести всіх користувачів");
    action = int.Parse(Console.ReadLine() ?? "0");
    switch (action)
    {
        case 0:
            Console.WriteLine("Вихід з програми.");
            break;
        case 1:
            AddFakeUsers();
            break;
        case 2:
            DisplayAllUsers();
            break;
        default:
            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            break;
    }
} while (action != 0);

void DisplayAllUsers()
{
    Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-UA");
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");
    using var context = new AppBeaverContext();
    var query = context.Users.AsQueryable();
    if (query.Count() == 0)
    {
        Console.WriteLine("Немає користувачів у базі даних.");
        return;
    }

    var items = query
        .OrderBy(x => x.LastName)
        .ThenBy(x => x.FistName)
        .Skip(1000) // Можна використовувати для пагінації
        .Take(10) // Обмеження на кількість користувачів для виведення
        .Select(x => new UserItemModel
    {
        Id = x.Id,
        Name = $"{x.LastName} {x.FistName}",
        Email = x.Email
    }).ToList(); 
    Console.WriteLine("Список всіх користувачів:");
    foreach (var user in items)
    {
        Console.WriteLine($"Id: {user.Id}, " +
            $"{user.Name}, " +
            $"Email: {user.Email}");
           // $"Дата створення: {user.CreatedAt.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss")}, " +
           // $"Дата оновлення: {user.UpdatedAt.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss")}");
    }
}

void AddFakeUsers()
{
    Console.WriteLine("Вкажіть кількість користувачів:");
    var fakeUserCount = int.Parse(Console.ReadLine() ?? "0");

    var faker = new Faker<UserEntity>("uk")
        .RuleFor(u => u.FistName, f => f.Name.FirstName())
        .RuleFor(u => u.LastName, f => f.Name.LastName())
        .RuleFor(u => u.Email, (f, u) => $"{u.FistName.ToLower()}.{u.LastName.ToLower()}@gmail.com")
        .RuleFor(u => u.CreatedAt, f => DateTime.Now.ToUniversalTime())
        .RuleFor(u => u.UpdatedAt, (f, u) => u.CreatedAt.AddDays(f.Random.Int(1, 30)).ToUniversalTime());

    for (int i = 0; i < fakeUserCount; i++)
    {
        var user = faker.Generate();
        using var context = new AppBeaverContext();
        context.Users.Add(user); // Додаємо нового користувача до контексту
        context.SaveChanges(); // Зберігаємо зміни в базі даних
        Console.WriteLine($"{i+1} - Додано користувача: {user.FistName} {user.LastName}, Email: {user.Email}, Id: {user.Id}");
    }
}



