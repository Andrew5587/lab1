namespace lab6;

partial class EditForm
{
    private System.ComponentModel.IContainer components = null;
    public TextBox txtName;
    public NumericUpDown numPrice;
    public CheckBox chkInStock;
    public ComboBox cmbType;
    public TextBox txtExtra;
    private Label lblName;
    private Label lblPrice;
    private Label lblType;
    private Label lblExtra;
    private Button btnOk;
    private Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        txtName = new TextBox();
        numPrice = new NumericUpDown();
        chkInStock = new CheckBox();
        cmbType = new ComboBox();
        txtExtra = new TextBox();
        lblName = new Label();
        lblPrice = new Label();
        lblType = new Label();
        lblExtra = new Label();
        btnOk = new Button();
        btnCancel = new Button();
        SuspendLayout();

        // Налаштування міток
        lblName.Text = "Назва:"; lblName.Location = new Point(20, 20);
        lblPrice.Text = "Ціна:"; lblPrice.Location = new Point(20, 60);
        lblType.Text = "Тип:"; lblType.Location = new Point(20, 100);
        lblExtra.Text = "Параметр:"; lblExtra.Location = new Point(20, 140);

        // Поля введення
        txtName.Location = new Point(120, 20); txtName.Size = new Size(150, 23);
        numPrice.Location = new Point(120, 60); numPrice.Maximum = 100000;
        chkInStock.Location = new Point(120, 180); chkInStock.Text = "В наявності";
        
        cmbType.Location = new Point(120, 100);
        cmbType.Items.AddRange(new object[] { "Laptop", "Smartphone" });
        cmbType.SelectedIndexChanged += (s, e) => {
            lblExtra.Text = cmbType.Text == "Laptop" ? "Процесор:" : "Батарея (mAh):";
        };

        txtExtra.Location = new Point(120, 140); txtExtra.Size = new Size(150, 23);

        // Кнопки
        btnOk.Location = new Point(50, 230); btnOk.Text = "OK"; btnOk.DialogResult = DialogResult.OK;
        btnCancel.Location = new Point(160, 230); btnCancel.Text = "Скасувати";

        // EditForm
        ClientSize = new Size(300, 300);
        Controls.AddRange(new Control[] { lblName, txtName, lblPrice, numPrice, lblType, cmbType, lblExtra, txtExtra, chkInStock, btnOk, btnCancel });
        Text = "Додати/Редагувати товар";
        ResumeLayout(false);
    }
}