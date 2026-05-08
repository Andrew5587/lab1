using System;
using System.Text.Json.Serialization;

namespace Core
{

    [JsonDerivedType(typeof(Laptop), typeDiscriminator: "laptop")]
    [JsonDerivedType(typeof(Smartphone), typeDiscriminator: "smartphone")]
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }

        // Пустой конструктор для корректной работы сериализации
        public Product() { }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Товар: {Name}, Ціна: {Price}$");
        }

        public abstract string GetCategory();
    }
}