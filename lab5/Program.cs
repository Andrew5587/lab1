using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using System.Linq;
using Core;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Laptop("ASUS Vivobook", 1200.50, true, "Intel Core i7"),
                new Smartphone("iPhone 15 Pro", 1100.00, true, 3274),
                new Laptop("Dell XPS 15", 2500.00, false, "Intel Core i9"),
                new Smartphone("Samsung Galaxy S24", 950.00, true, 4000)
            };

            string jsonPath = "products.json";
            string xmlPath = "available_products.xml";
            string logPath = "system.log";

            Console.WriteLine("--- Лабораторна робота №5 ---");

            using (LogManager logger = new LogManager(logPath))
            {
                logger.Log("Програма запущена. Початок роботи з даними.");

                // --- ПУНКТ 2: JSON Збереження ---
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(products, options);
                File.WriteAllText(jsonPath, jsonString);
                Console.WriteLine($"\nДані успішно серіалізовані у файл: {jsonPath}");
                logger.Log("Дані збережено у JSON форматі.");

                // --- ПУНКТ 6: Валідація та обробка помилок (Десеріалізація) ---
                if (File.Exists(jsonPath)) // Перевірка існування файлу
                {
                    try
                    {
                        string readJson = File.ReadAllText(jsonPath);
                        var restoredProducts = JsonSerializer.Deserialize<List<Product>>(readJson);

                        Console.WriteLine("\nОб'єкти, відновлені з JSON-файлу:");
                        if (restoredProducts != null)
                        {
                            foreach (var product in restoredProducts)
                            {
                                product.DisplayInfo();
                            }
                        }
                        logger.Log("Дані успішно десеріалізовано з JSON.");
                    }
                    catch (JsonException ex) // Відловлюємо помилку пошкодженого JSON
                    {
                        Console.WriteLine($"\n[Помилка десеріалізації]: Файл {jsonPath} пошкоджено або має неправильний формат.");
                        Console.WriteLine($"Деталі: {ex.Message}");
                        logger.Log($"ПОМИЛКА: JSON файл пошкоджено. {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"\n[Помилка]: Файл {jsonPath} не знайдено!");
                    logger.Log($"ПОМИЛКА: Файл {jsonPath} не існує.");
                }

                // --- ПУНКТ 3: XML та LINQ ---
                Console.WriteLine("\n--- Пункт 3: Робота з XML через XDocument та LINQ ---");
                XDocument xmlDoc = new XDocument(
                    new XElement("Store",
                        products.Where(p => p.InStock)
                                .Select(p => new XElement("Product",
                                    new XAttribute("Category", p.GetCategory()),
                                    new XElement("Name", p.Name),
                                    new XElement("Price", p.Price)
                                ))
                    )
                );
                
                xmlDoc.Save(xmlPath);
                Console.WriteLine($"Товари в наявності успішно експортовані у XML файл: {xmlPath}");
                logger.Log("Відфільтровані дані експортовано у XML.");
                
            } 
        }
    }
}