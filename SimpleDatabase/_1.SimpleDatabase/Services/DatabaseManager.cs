using Microsoft.Extensions.Configuration;
using Npgsql;

namespace _1.SimpleDatabase.Services;

public class DatabaseManager : IDisposable
{
    private readonly NpgsqlConnection _conn;
    public DatabaseManager()
    {
        var conf = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connStr = conf["ConnectionStrings:DefaultConnection"];
        _conn = new NpgsqlConnection(connStr);
        _conn.Open();
    }

    public void ExecuteCreateTabels()
    {
        string dir = Path.Combine(Directory.GetCurrentDirectory(), "SqlScripts", "tabels");
        if (!Directory.Exists(dir))
        {
            Console.WriteLine($"Директорія {dir} не існує.");
            return;
        }
        // Зчитування SQL скриптів з файлів у директорії
        var files = Directory.GetFiles(dir, "*.sql");
        foreach (var file in files)
        {
            string sql = File.ReadAllText(file);
            using (var cmd = new NpgsqlCommand(sql, _conn))
            {
                // Отримати результат з першого рядку таблиці, яку прочитали
                var result = cmd.ExecuteNonQuery();
                Console.WriteLine($"{Path.GetFileName(file)} -- {result}");
            }
        }
    }

    public void Dispose()
    {
        _conn.Dispose();
    }
}
