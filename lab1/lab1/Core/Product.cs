using System;

namespace Core
{
    public class Product
    {
        // Назва товару
        public string Name { get; set; }

        // Ціна товару
        public double Price { get; set; }

        // Чи є товар у наявності
        public bool InStock { get; set; }
    }
}