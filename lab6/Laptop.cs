using System;

namespace Core
{
    public class Laptop : Product, IDisplayable
    {
        public string Processor { get; set; }

        // Конструктор без параметрів (вимога для серіалізації)
        public Laptop() { }

        // Конструктор з параметрами для зручного створення об'єктів
        public Laptop(string name, double price, bool inStock, string processor)
        {
            Name = name;
            Price = price;
            InStock = inStock;
            Processor = processor;
        }

        public override string GetCategory()
        {
            return "Ноутбуки";
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo(); 
            Console.WriteLine($"Процесор: {Processor}, Категорія: {GetCategory()}");
        }

        public void ShowTechnicalDetails()
        {
            Console.WriteLine($"[IDisplayable]: Технічні дані ноутбука — Процесор: {Processor}");
        }
    }
}