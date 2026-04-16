using System;

namespace Core
{
    //abstract 
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }

        // virtual
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Товар: {Name}, Ціна: {Price}$");
        }

        //abstract
        public abstract string GetCategory();
    }
}