using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using Core;

namespace ConsoleUI
{
    public struct ComputerSpecs
    {
        public int Ram;
        public int Storage;
        public ComputerSpecs(int ram, int storage)
        {
            Ram = ram;
            Storage = storage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // --- ТЕХНІЧНА ІНФОРМАЦІЯ ---
            Console.WriteLine("Інформація про систему:");
            Console.WriteLine($"Версія ОС: {Environment.OSVersion}");
            long memoryUsed = GC.GetTotalMemory(false);
            Console.WriteLine($"Використана пам'ять додатком: {memoryUsed} байт");

            // --- ЗАВДАННЯ 2: Робота зі структурами ---
            Console.WriteLine("\n=== Завдання 2: Робота зі структурами ===");
            ComputerSpecs mySpecs = new ComputerSpecs(16, 512);
            Console.WriteLine($"До методу: RAM = {mySpecs.Ram}");
            TryChangeStruct(mySpecs);
            Console.WriteLine($"Після методу: RAM = {mySpecs.Ram}");

            // --- ЗАВДАННЯ 3: Аналіз Boxing/Unboxing ---
            Console.WriteLine("\n=== Завдання 3: Аналіз Boxing/Unboxing ===");
            AnalyzePerformance();

            // --- ЗАВДАННЯ 4: Створення колекції об'єктів ---
            Console.WriteLine("\n=== Завдання 4: Колекція об'єктів (10 елементів) ===");
            List<Product> products = new List<Product>
            {
                new Product { Name = "Asus ROG Strix", Price = 2500.0, InStock = true },
                new Product { Name = "MacBook Air M2", Price = 1200.0, InStock = true },
                new Product { Name = "Lenovo ThinkPad", Price = 1500.0, InStock = false },
                new Product { Name = "HP Pavilion", Price = 850.0, InStock = true },
                new Product { Name = "Dell XPS 15", Price = 2100.0, InStock = true },
                new Product { Name = "Acer Aspire 7", Price = 750.0, InStock = true },
                new Product { Name = "MSI Katana", Price = 1100.0, InStock = false },
                new Product { Name = "Gigabyte G5", Price = 900.0, InStock = true },
                new Product { Name = "Samsung Galaxy Book", Price = 1350.0, InStock = true },
                new Product { Name = "Microsoft Surface", Price = 1600.0, InStock = false }
            };

            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} (Ціна: {p.Price}, В наявності: {p.InStock})");
            }

            // --- ЗАВДАННЯ 5: Фільтрація LINQ ---
            Console.WriteLine("\n=== Завдання 5: Фільтрація LINQ (Ціна > 1000) ===");
            var expensiveProducts = products.Where(p => p.Price > 1000).ToList();
            foreach (var p in expensiveProducts) { Console.WriteLine($"- {p.Name}: {p.Price}"); }

            // --- ЗАВДАННЯ 6: Сортування LINQ ---
            Console.WriteLine("\n=== Завдання 6: Сортування (Наявність -> Ціна) ===");
            var sortedProducts = products.OrderBy(p => p.InStock).ThenBy(p => p.Price).ToList();
            foreach (var p in sortedProducts) { Console.WriteLine($"- В наявності: {p.InStock} | Ціна: {p.Price} | Назва: {p.Name}"); }

            // --- ЗАВДАННЯ 7: Проекція даних (Select) ---
            Console.WriteLine("\n=== Завдання 7: Проекція (Тільки назви товарів) ===");
            List<string> productNames = products.Select(p => p.Name).ToList();
            foreach (string name in productNames) { Console.WriteLine($"- {name}"); }

            // --- ЗАВДАННЯ 8: Виконати пошук елемента (FirstOrDefault) ---
            Console.WriteLine("\n=== Завдання 8: Пошук елемента (Перший Dell дорожче 2000) ===");
            
            // Шукаємо перший об'єкт за умовою 
            var searchResult = products.FirstOrDefault(p => p.Name.Contains("Dell") && p.Price > 2000);

           // Обробимо ситуацію, якщо об'єкт не знайдено (перевірка на null) 
            if (searchResult != null)
            {
                Console.WriteLine($"Знайдено об'єкт: {searchResult.Name} з ціною {searchResult.Price}");
            }
            else
            {
                Console.WriteLine("Об'єкт, що відповідає заданим критеріям, не знайдено.");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        static void TryChangeStruct(ComputerSpecs specs) { specs.Ram = 999; Console.WriteLine($"Всередині методу: RAM = {specs.Ram}"); }
        
        static void AnalyzePerformance()
        {
            int iterations = 1000000;
            Stopwatch sw = new Stopwatch();
            ArrayList al = new ArrayList(); sw.Start();
            for (int i = 0; i < iterations; i++) al.Add(i);
            sw.Stop(); long t1 = sw.ElapsedMilliseconds;
            sw.Restart();
            List<int> gl = new List<int>();
            for (int i = 0; i < iterations; i++) gl.Add(i);
            sw.Stop(); long t2 = sw.ElapsedMilliseconds;
            Console.WriteLine($"ArrayList: {t1} ms | List<int>: {t2} ms | Різниця: {t1 - t2} ms");
        }
    }
}