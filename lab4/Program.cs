using System;
using System.Collections.Generic;
using Core;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Створюємо список товарів (Агрегація: створюємо ПОЗА контролером)
            List<Product> catalog = new List<Product>
            {
                new Laptop { Name = "Asus ROG", Price = 2500, Processor = "Intel i9" },
                new Smartphone { Name = "iPhone 15", Price = 1200, BatteryCapacity = 4500 },
                new Laptop { Name = "MacBook M3", Price = 2100, Processor = "Apple M3" }
            };

            Console.WriteLine("=== Пункт 4-5: Композиція та Агрегація ===");
            // Створюємо контролер (Композиція всередині, Агрегація через catalog)
            StoreController store = new StoreController("Техно-Світ", catalog);
            store.PrintStoreStatus();

            Console.WriteLine("\n=== Пункт 6: Поліморфізм через інтерфейси ===");
            
            // Створюємо масив інтерфейсного типу
            IDisplayable[] devices = new IDisplayable[]
            {
                (IDisplayable)catalog[0],
                (IDisplayable)catalog[1],
                (IDisplayable)catalog[2]
            };

            // Викликаємо метод інтерфейсу в одному циклі для різних об'єктів
            foreach (var device in devices)
            {
                device.ShowTechnicalDetails();
            }

            Console.WriteLine("\n=== Демонстрація віртуальних методів ===");
            foreach (var product in catalog)
            {
                product.DisplayInfo(); // Виклик перевизначеного (override) методу
            }

            Console.ReadKey();
        }
    }
}