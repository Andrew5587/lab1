using System;

namespace Core
{
    // Нащадок класу Product
    public class Laptop : Product, IDisplayable
    {
        public string Processor { get; set; }

        // Реалізація обов'язкового абстрактного методу
        public override string GetCategory()
        {
            return "Ноутбуки";
        }
        // Перевизначення віртуального методу 
        public override void DisplayInfo()
        {
            base.DisplayInfo(); 
            Console.WriteLine($"Процесор: {Processor}, Категорія: {GetCategory()}");
        }
        // Реалізація методу інтерфейсу IDisplayable
        public void ShowTechnicalDetails()
        {
            Console.WriteLine($"[IDisplayable]: Технічні дані ноутбука — Процесор: {Processor}");
        }
    }
}