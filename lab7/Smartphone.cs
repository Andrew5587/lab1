using System;

namespace lab7
{
    public class Smartphone : Product, IDisplayable
    {
        public int BatteryCapacity { get; set; }

        public Smartphone() { }

        public Smartphone(string name, double price, bool inStock, int batteryCapacity)
        {
            Name = name;
            Price = price;
            InStock = inStock;
            BatteryCapacity = batteryCapacity;
        }

        public override string GetCategory()
        {
            return "Смартфоны";
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Батарея: {BatteryCapacity} mAh, Категория: {GetCategory()}");
        }

        public void ShowTechnicalDetails()
        {
            Console.WriteLine($"[IDisplayable]: Технические данные смартфона — Батарея: {BatteryCapacity} mAh");
        }
    }
}