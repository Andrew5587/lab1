namespace lab6;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvProducts;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnSave;
    private Button btnLoad;
    private Panel panelButtons;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvProducts = new DataGridView();
        btnAdd = new Button();
        btnDelete = new Button();
        btnSave = new Button();
        btnLoad = new Button();
        panelButtons = new Panel();

        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        panelButtons.SuspendLayout();
        SuspendLayout();

        // Налаштування таблиці
        dgvProducts.Dock = DockStyle.Top;
        dgvProducts.Height = 200;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Панель для кнопок
        panelButtons.Dock = DockStyle.Fill;
        panelButtons.Controls.Add(btnAdd);
        panelButtons.Controls.Add(btnDelete);
        panelButtons.Controls.Add(btnSave);
        panelButtons.Controls.Add(btnLoad);

        // Кнопки
        btnAdd.Location = new Point(20, 20); btnAdd.Size = new Size(100, 35); btnAdd.Text = "Додати";
        btnAdd.Click += btnAdd_Click;

        btnDelete.Location = new Point(130, 20); btnDelete.Size = new Size(100, 35); btnDelete.Text = "Видалити";
        btnDelete.Click += btnDelete_Click;

        btnSave.Location = new Point(20, 65); btnSave.Size = new Size(100, 35); btnSave.Text = "Зберегти";
        btnSave.Click += btnSave_Click;

        btnLoad.Location = new Point(130, 65); btnLoad.Size = new Size(100, 35); btnLoad.Text = "Завантажити";
        btnLoad.Click += btnLoad_Click;

        // Налаштування форми Form1
        ClientSize = new Size(260, 320);
        Controls.Add(panelButtons);
        Controls.Add(dgvProducts);
        Name = "Form1";
        Text = "Лабораторна 6";

        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }
}