using EntityExample.Data;
using EntityExample.Data.Entities;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Хороша погода");

var user = new UserEntity
{
    FistName = "Іван",
    LastName = "Брусок",
    Email = "ivan@gmail.com"
};

using var context = new AppBeaverContext();
context.Users.Add(user); // Додаємо нового користувача до контексту
context.SaveChanges(); // Зберігаємо зміни в базі даних

Console.WriteLine($"User id = {user.Id}");
