using SportGoodsProject.Models;
using SportGoodsProject.Properties;
using Microsoft.EntityFrameworkCore; // ДЛЯ Include() - САМОЕ ВАЖНОЕ!
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace SportGoodsProject
{
    public partial class FormProducts : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormProducts(User user, bool guest)
        {
            InitializeComponent();

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;   //относиельная ширина в процентах

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;  //перенос строки

            var colDiscount = new DataGridViewTextBoxColumn();
            colDiscount.Name = "colDiscount";
            colDiscount.FillWeight = 10;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.AddRange(
            [
                colPhoto, colInfo, colDiscount
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            // Используем лямбда-выражение для VisibleChanged
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible)
                {
                    dgvProducts.ClearSelection();
                }
            };

            LoadProducts();

               /*            
                this - текущая форма
                .Load - событие, которое происходит один раз когда форма полностью загружена в память, но еще не отобразилась на экране

                2. +=
                "Добавить обработчик" - подписываемся на событие

                Когда произойдет событие Load, выполнится наш код

                3. (s, e) =>
                Лямбда - выражение(короткая анонимная функция)

                s(sender) - кто вызвал событие(форма)

                e(event args) - параметры события (обычно пустые)

                => - "выполнить следующий код"

                4. dgvProducts.ClearSelection()
                Конкретное действие: убрать выделение в DataGridView

                Выполнится автоматически при загрузке формы*/
            this.Load += (s, e) => dgvProducts.ClearSelection();
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = new SportGoodsDbContext())
                {
                    var tovars = db.Tovars
                        //загрузка сущностей
                        .Include(i => i.Category)
                        .Include(i => i.Manufacturer)
                        .Include(i => i.Supplier)
                        .ToList();

                    dgvProducts.SuspendLayout();    //приостанавливает отрисовку
                    dgvProducts.Rows.Clear();

                    foreach (var tovar in tovars)
                    {
                        int rowIndex = dgvProducts.Rows.Add();  //добавление строки
                        var row = dgvProducts.Rows[rowIndex];   //указываем какая текущая строка

                        row.Cells["colPhoto"].Value = LoadProductImage(null);

                        row.Cells["colInfo"].Value = FormatProductInfo(tovar);

                        row.Cells["colDiscount"].Value = $"{tovar.Discount}%";
                        row.Cells["colDiscount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        ApplyRowStyles(row, tovar);
                    }

                    //возобновить отрисовку
                    dgvProducts.ResumeLayout();
                    //высота строк по содержимому
                    dgvProducts.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                    /*dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvProducts.ClearSelection();*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка загрузки: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ApplyRowStyles(DataGridViewRow row, Tovar tovar)
        {
            if (tovar.Discount > 15)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2EC4B6");
                //row.DefaultCellStyle.ForeColor = Color.White; //если надо будет цвет белый на скидке
            }

            if (tovar.CountTovar <= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightBlue;
            }

            if (tovar.Discount > 0)
            {
                row.Cells["colDiscount"].Style.ForeColor = Color.Red;
                row.Cells["colDiscount"].Style.Font = new Font(
                    "Times New Roman",
                    12,
                    FontStyle.Bold
                );
            }
        }

        private string FormatProductInfo(Tovar tovar)
        {
            string priceText;

            if (tovar.Discount > 0)
            {
                decimal finalPrice = tovar.Price * (100 - tovar.Discount) / 100;
                priceText = $"{ToStrikeThrough(tovar.Price)}   -> {finalPrice:C}";
            }
            else
            {
                priceText = $"{tovar.Price:C}";
            }

            return $"{tovar.Category.CategoryName} | {tovar.TovarName}\n" +
                $"Описание товара: {tovar.Description}\n" +
                $"Производитель: {tovar.Manufacturer}\n" +
                $"Поставщик: {tovar.Supplier.SupplierName}\n" +
                $"Цена: {priceText}\n" +
                $"Кол-во на складе: {tovar.CountTovar}";
        }

        private string ToStrikeThrough(decimal price)
        {
            string priceStr = price.ToString("C");
            return string.Join("\u0336", priceStr.ToCharArray()) + "\u0336";
        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;
        }

        private void BtnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;    //выйти
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult = DialogResult.Abort;  //назад
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}