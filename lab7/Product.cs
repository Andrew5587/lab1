using System;
using System.Text.Json.Serialization;

namespace lab7
{
    [JsonDerivedType(typeof(Laptop), typeDiscriminator: "laptop")]
    [JsonDerivedType(typeof(Smartphone), typeDiscriminator: "smartphone")]
    public abstract class Product
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public bool InStock { get; set; }

        public Product() { }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Товар: {Name}, Ціна: {Price}$");
        }

        public abstract string GetCategory();
    }
}