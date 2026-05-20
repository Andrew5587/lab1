using System.Windows;
using System.Collections.ObjectModel;

namespace lab7
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> MyProducts { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MyProducts = new ObservableCollection<Product>
            {
                new Laptop { Name = "Asus L1", Price = 25000, InStock = true },
                new Smartphone { Name = "iPhone 15", Price = 45000, InStock = false }
            };

            dgProducts.ItemsSource = MyProducts;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addWin = new AddProductWindow();
            addWin.Owner = this;

            if (addWin.ShowDialog() == true)
            {
                if (addWin.NewProduct != null)
                {
                    MyProducts.Add(addWin.NewProduct);
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ви натиснули кнопку: Редагувати");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ви натиснули кнопку: Видалити");
        }
    }
}