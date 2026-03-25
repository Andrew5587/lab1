using System;

namespace Core
{
    public class CartItem
    {
        // Назва товару у кошику
        public string ProductName { get; set; } = "";

        // Кількість товару
        public int Quantity { get; set; }

        // Загальна ціна товарів
        public double TotalPrice { get; set; }
    }
}