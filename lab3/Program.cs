using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Використання ієрархії класів
            List<Product> products = new List<Product>
            {
                new Product { Name = "Asus ROG Strix", Price = 2500.0, InStock = true },
                new Product { Name = "MacBook Air M2", Price = 1200.0, InStock = true },
                new Product { Name = "Lenovo ThinkPad", Price = 1500.0, InStock = false },
                new Product { Name = "HP Pavilion", Price = 850.0, InStock = true },
                new Product { Name = "Dell XPS 15", Price = 2100.0, InStock = true }
            };

            Console.WriteLine("=== Пункт 1: Список товарів ===");
            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} (Ціна: {p.Price}$, В наявності: {p.InStock})");
            }

            // 2. Методи розширення
            Console.WriteLine("\n=== Пункт 2: Методи розширення ===");
            var testProduct = products[0];
            Console.WriteLine($"Товар: {testProduct.Name} | Ціна: {testProduct.Price.ToCurrencyString()} | Преміум: {testProduct.IsPremium()}");

            // 3-4. Створення контейнера та протокол ітерації
            Console.WriteLine("\n=== Пункт 3-4: Контейнер Storage та ітерація foreach ===");
            Storage myStorage = new Storage();
            
            foreach (var p in products)
            {
                myStorage.Add(p);
            }

            Console.WriteLine("Товари з контейнера (через yield return):");
            foreach (Product item in myStorage)
            {
                Console.WriteLine($"-> {item.Name}");
            }

            // 5. Робота з Dictionary та LINQ (Інтерактивний пошук)
            Console.WriteLine("\n=== Пункт 5: Швидкий пошук через Dictionary та LINQ ===");
            
            Dictionary<string, Product> productDict = myStorage.AllItems.ToDictionary(p => p.Name);

            Console.Write("Введіть назву товару для пошуку: ");
            string searchKey = Console.ReadLine() ?? "";

            if (productDict.TryGetValue(searchKey, out Product foundProduct))
            {
                Console.WriteLine($"[Знайдено]: {foundProduct.Name} за {foundProduct.Price}$");
            }
            else
            {
                Console.WriteLine("Товар з такою назвою не знайдено.");
            }

            Console.Write("\nВведіть мінімальну ціну для фільтрації: ");
            string inputPrice = Console.ReadLine() ?? "0";
            if (double.TryParse(inputPrice, out double minPrice))
            {
                var filteredProducts = productDict.Where(pair => pair.Value.Price > minPrice);
                
                Console.WriteLine($"Товари дорожче {minPrice}$:");
                foreach (var pair in filteredProducts)
                {
                    Console.WriteLine($"- {pair.Key}: {pair.Value.Price}$");
                }
            }

            // 6. Робота з HashSet 
            Console.WriteLine("\n=== Пункт 6: Робота з HashSet (множини) ===");
            HashSet<string> setA = new HashSet<string> { "Laptops", "Gaming", "Work" };
            HashSet<string> setB = new HashSet<string> { "Gaming", "Sale", "Work" };
            
            setA.IntersectWith(setB); // Залишаємо тільки спільні елементи
            Console.WriteLine($"Спільні категорії: {string.Join(", ", setA)}");
            
            Console.ReadKey();
        }
    }
}