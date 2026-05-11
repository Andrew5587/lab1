using System.Windows;

namespace lab7
{
    public partial class AddProductWindow : Window
    {
        public Product? NewProduct { get; private set; }

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbPrice.Text, out double price))
            {
                NewProduct = new Laptop 
                { 
                    Name = tbName.Text, 
                    Price = price, 
                    InStock = cbInStock.IsChecked ?? false 
                };
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введіть коректну ціну!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}