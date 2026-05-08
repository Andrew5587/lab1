using System;
using System.IO;

namespace Core
{
    public class LogManager : IDisposable
    {
        private readonly StreamWriter _writer;

        public LogManager(string path)
        {
            // Відкриваємо файл для запису. append: true означає, що нові записи 
            // будуть додаватися в кінець файлу, а не перезаписувати його.
            _writer = new StreamWriter(path, append: true);
        }

        public void Log(string message)
        {
            // Записуємо повідомлення разом із поточним часом
            _writer.WriteLine($"{DateTime.Now:G}: {message}");
        }

        // Цей метод вимагається інтерфейсом IDisposable
        public void Dispose()
        {
            _writer?.Dispose(); // Гарантовано закриваємо файл і звільняємо ресурс
            Console.WriteLine("\n[Системне повідомлення]: LogManager ресурс успішно звільнено (виклик Dispose).");
        }
    }
}