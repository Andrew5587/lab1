using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO; // Додано для роботи з файлами
using System.Runtime.CompilerServices;
using System.Text.Json; // Додано для роботи з JSON
using System.Windows.Input;

namespace lab8.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object? parameter) => _execute(parameter);
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private static readonly string FilePath = "products.json"; // Назва файлу для збереження
        public ObservableCollection<Product> Products { get; set; }

        private Product? _selectedProduct;
        public Product? SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();
            
            // Завантажуємо дані з файлу при старті програми
            LoadData();

            // Якщо файл порожній або його немає, створюємо початкові дані
            if (Products.Count == 0)
            {
                Products.Add(new Laptop { Name = "Asus L1", Price = 25000, InStock = true });
                Products.Add(new Smartphone { Name = "iPhone 15", Price = 45000, InStock = false });
                SaveData(); // Одразу створюємо файл на диску
            }

            AddCommand = new RelayCommand(obj =>
            {
                Products.Add(new Smartphone { Name = "New Device", Price = 10000, InStock = true });
                SaveData(); // Зберігаємо зміни у файл
            });

            DeleteCommand = new RelayCommand(obj =>
            {
                if (SelectedProduct != null)
                {
                    Products.Remove(SelectedProduct);
                    SaveData(); // Зберігаємо зміни у файл
                }
            }, obj => SelectedProduct != null);
        }

        // Метод для збереження даних у JSON
        private void SaveData()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Products, options);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Помилка збереження: {ex.Message}");
            }
        }

        // Метод для завантаження даних з JSON
        private void LoadData()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string jsonString = File.ReadAllText(FilePath);
                    var deserialized = JsonSerializer.Deserialize<ObservableCollection<Product>>(jsonString);
                    if (deserialized != null)
                    {
                        Products.Clear();
                        foreach (var item in deserialized)
                        {
                            Products.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Помилка завантаження: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}