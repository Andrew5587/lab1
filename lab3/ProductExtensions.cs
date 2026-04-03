using System;

namespace Core
{
    public static class ProductExtensions
    {
        // Метод розширення для форматування ціни з символом валюти
        public static string ToCurrencyString(this double price)
        {
            return $"{price:F2} USD";
        }

        // Метод розширення для перевірки, чи є товар "преміальним" (дорожче 1500)
        public static bool IsPremium(this Product product)
        {
            return product.Price > 1500;
        }
    }
}