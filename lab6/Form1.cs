using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Core;

namespace lab6
{
    public partial class Form1 : Form
    {
        // Список товарів та джерело прив'язки (Пункт 1)
        private List<Product> _products = new List<Product>();
        private BindingSource _source = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            
            // Налаштування автоматичного відображення в таблиці (Пункт 3)
            _source.DataSource = _products;
            dgvProducts.DataSource = _source;
        }

        // --- ПУНКТ 5: ДОДАВАННЯ ТА ВИДАЛЕННЯ ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Виклик діалогового вікна EditForm (Пункт 4)
            using (EditForm editForm = new EditForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Додаємо новий об'єкт у список через BindingSource
                    _source.Add(editForm.ResultProduct);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                // Підтвердження видалення через MessageBox (Пункт 5)
                var result = MessageBox.Show(
                    "Ви впевнені, що хочете видалити цей елемент?", 
                    "Підтвердження", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _source.RemoveCurrent();
                }
            }
            else
            {
                MessageBox.Show("Виберіть рядок для видалення!");
            }
        }

        // --- ПУНКТ 6: ЗБЕРЕЖЕННЯ ТА ЗАВАНТАЖЕННЯ (JSON) ---

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON файли (*.json)|*.json";
                sfd.Title = "Збереження даних";
                sfd.FileName = "products.json";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Налаштування для гарного вигляду JSON (відступи)
                        var options = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = JsonSerializer.Serialize(_products, options);
                        
                        File.WriteAllText(sfd.FileName, jsonString);
                        MessageBox.Show("Дані успішно збережено у файл!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при збереженні: {ex.Message}", "Помилка");
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON файли (*.json)|*.json";
                ofd.Title = "Завантаження даних";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonString = File.ReadAllText(ofd.FileName);
                        
                        // Десеріалізація списку об'єктів
                        var loadedProducts = JsonSerializer.Deserialize<List<Product>>(jsonString);

                        if (loadedProducts != null)
                        {
                            _products.Clear();
                            _products.AddRange(loadedProducts);
                            
                            // Важливо: оновлюємо таблицю після зміни списку вручну
                            _source.ResetBindings(false);
                            
                            MessageBox.Show("Дані успішно завантажено!", "Успіх");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при завантаженні: {ex.Message}", "Помилка");
                    }
                }
            }
        }
    }
}