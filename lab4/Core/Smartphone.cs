using System;

namespace Core
{
    // Нащадок класу Product
    public class Smartphone : Product, IDisplayable
    {
        public int BatteryCapacity { get; set; }

        public override string GetCategory()
        {
            return "Смартфони";
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Батарея: {BatteryCapacity} mAh, Категорія: {GetCategory()}");
        }

        // Реалізація методу інтерфейсу IDisplayable
        public void ShowTechnicalDetails()
        {
            Console.WriteLine($"[IDisplayable]: Технічні дані смартфона — Батарея: {BatteryCapacity} mAh");
        }
    }
}