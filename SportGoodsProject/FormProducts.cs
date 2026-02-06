using Microsoft.EntityFrameworkCore;
using SportGoodsProject.Models;
using SportGoodsProject.Properties;

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
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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

            LoadProducts();

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

                    dgvProducts.SuspendLayout();    
                    dgvProducts.Rows.Clear();

                    foreach (var tovar in tovars)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["colPhoto"].Value = LoadProductImage(null);

                        row.Cells["colInfo"].Value = FormatProductInfo(tovar);

                        row.Cells["colDiscount"].Value = $"{tovar.Discount}%";
                        row.Cells["colDiscount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        ApplyRowStyles(row, tovar);
                    }

                    dgvProducts.ResumeLayout();
                    dgvProducts.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
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
            }

            if (tovar.CountTovar <= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private string FormatProductInfo(Tovar tovar)
        {
            string priceText;

            if (tovar.Discount > 0)
            {
                decimal finalPrice = tovar.Price * (100 - tovar.Discount) / 100;
                string oldPrice = "";
                foreach (char c in tovar.Price.ToString("C")) { 
                    oldPrice += c + "\u0336";
                }
                priceText = $"{oldPrice} → {finalPrice:C}";
            }
            else
            {
                priceText = $"{tovar.Price:C}";
            }

            return $"{tovar.Category.CategoryName} | {tovar.TovarName}\n" +
                $"Описание товара2: {tovar.Description}\n" +
                $"Производитель: {tovar.Manufacturer}\n" +
                $"Поставщик: {tovar.Supplier.SupplierName}\n" +
                $"Цена: {priceText}\n" +
                $"Кол-во на складе: {tovar.CountTovar}";
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