using System;

namespace lab8
{
    public class Laptop : Product, IDisplayable
    {
        public string Processor { get; set; }

        public Laptop() { }

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
            Console.WriteLine($"Процессор: {Processor}, Категория: {GetCategory()}");
        }

        public void ShowTechnicalDetails()
        {
            Console.WriteLine($"[IDisplayable]: Технические данные ноутбука — Процессор: {Processor}");
        }
    }
}