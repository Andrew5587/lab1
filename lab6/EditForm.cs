using Core;
namespace lab6;

public partial class EditForm : Form
{
    public Product ResultProduct { get; private set; }

    public EditForm()
    {
        InitializeComponent();
        cmbType.SelectedIndex = 0; // За замовчуванням Laptop
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
        if (DialogResult == DialogResult.OK)
        {
            string name = txtName.Text;
            double price = (double)numPrice.Value;
            bool inStock = chkInStock.Checked;

            if (cmbType.Text == "Laptop")
                ResultProduct = new Laptop(name, price, inStock, txtExtra.Text);
            else
                ResultProduct = new Smartphone(name, price, inStock, int.Parse(txtExtra.Text));
        }
    }
}