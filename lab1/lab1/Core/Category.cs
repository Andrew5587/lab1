using System;

namespace Core
{
    public class Category
    {
        // Назва категорії
        public string Title { get; set; }

        // Кількість товарів у категорії
        public int ProductCount { get; set; }

        // Дата створення категорії
        public DateTime CreatedDate { get; set; }
    }
}