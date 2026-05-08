using System;

namespace Core
{
    public class Smartphone : Product, IDisplayable
    {
        public int BatteryCapacity { get; set; }

        // Конструктор без параметрів (вимога для серіалізації)
        public Smartphone() { }

        // Конструктор з параметрами (для зручності)
        public Smartphone(string name, double price, bool inStock, int batteryCapacity)
        {
            Name = name;
            Price = price;
            InStock = inStock;
            BatteryCapacity = batteryCapacity;
        }

        public override string GetCategory()
        {
            return "Смартфони";
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Батарея: {BatteryCapacity} mAh, Категорія: {GetCategory()}");
        }

        public void ShowTechnicalDetails()
        {
            Console.WriteLine($"[IDisplayable]: Технічні дані смартфона — Батарея: {BatteryCapacity} mAh");
        }
    }
}