using System.Linq;
using Xunit;
using lab8.ViewModels;
using lab8;

namespace lab8.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void Test_CollectionInitialization_HasTwoItems()
        {
            // Перевірка базової валідації : чи створюється колекція с 2 елементами
            // Arrange & Act
            var viewModel = new MainViewModel();

            // Assert
            Assert.Equal(2, viewModel.Products.Count);
        }

        [Fact]
        public void Test_LinqFiltering_InStockProducts()
        {
            // Перевірка фільтрації через LINQ: рахуємо товари, які є на складі
            // Arrange
            var viewModel = new MainViewModel();
            // Добавляем еще один товар на склад для проверки
            viewModel.Products.Add(new Laptop { Name = "Test Laptop", Price = 1000, InStock = true });

            // Act
            var inStockCount = viewModel.Products.Count(p => p.InStock);

            // Assert
            // Повино бути 2 (Asus L1 из основної колекції + Test Laptop). iPhone 15 не на складі.
            Assert.Equal(2, inStockCount); 
        }

        [Fact]
        public void Test_Calculation_TotalPrice()
        {
            // Перевірка розрахунків: сумарна вартість товаров
            // Arrange
            var viewModel = new MainViewModel();
            
            // Act
            var totalPrice = viewModel.Products.Sum(p => p.Price);

            // Assert
            // 25000 (Asus L1) + 45000 (iPhone 15) = 70000
            Assert.Equal(70000, totalPrice); 
        }
    }
}