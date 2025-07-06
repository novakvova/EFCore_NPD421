// See https://aka.ms/new-console-template for more information
using _1.SimpleDatabase.Services;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

DatabaseManager databaseManager = new DatabaseManager();

int action = 0;
do {     
    Console.WriteLine("Виберіть дію:");
    Console.WriteLine("0. Вийти");
    Console.WriteLine("1. Створити таблиці");
    
    if (!int.TryParse(Console.ReadLine(), out action))
    {
        Console.WriteLine("Будь ласка, введіть коректне число.");
        continue;
    }
    switch (action)
    {
        case 1:
            databaseManager.ExecuteCreateTabels();
            break;
        case 0:
            Console.WriteLine("Вихід з програми.");
            break;
        default:
            Console.WriteLine("Невідома дія. Спробуйте ще раз.");
            break;
    }
} while (action != 0);
