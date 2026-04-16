using System;
using System.Collections.Generic; 
using Core;

namespace lab4
{
    public class StoreConfiguration
    {
        public string StoreName { get; set; }
        public string Currency { get; set; }

        public StoreConfiguration(string name, string currency)
        {
            StoreName = name;
            Currency = currency;
        }
    }

    public class StoreController
    {
        // Композиція 
        private StoreConfiguration _config;

        // 5. Агрегація
        private List<Product> _catalog;

        public StoreController(string storeName, List<Product> externalCatalog)
        {
            // Композиція
            _config = new StoreConfiguration(storeName, "USD");
            
            // Агрегація
            _catalog = externalCatalog;
            
            Console.WriteLine($"[AGGREGATION]: Каталог на {_catalog.Count} товарів успішно підключено.");
        }

        public void PrintStoreStatus()
        {
            Console.WriteLine($"Магазин: {_config.StoreName}, Валюта: {_config.Currency}");
            Console.WriteLine("Список товарів у каталозі:");
            foreach (var item in _catalog)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }
}