// See https://aka.ms/new-console-template for more information
Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Привіт Команда!");

string connStr = "Host=ep-little-king-a2zmnpi8-pooler.eu-central-1.aws.neon.tech;" +
    "Database=neondb;" +
    "Username=neondb_owner;" +
    "Password=npg_hPA69mJiYolg;";

using (var conn = new Npgsql.NpgsqlConnection(connStr))
{
    conn.Open();
    Console.WriteLine("Підключення до бази даних успішне!");
    using (var cmd = new Npgsql.NpgsqlCommand("SELECT version();", conn))
    {
        // Отримати результат з першого рядку таблиці, яку прочитали
        var version = cmd.ExecuteScalar().ToString();
        Console.WriteLine($"Версія бази даних: {version}");
    }
    // Додайте тут ваш код для роботи з базою даних
}