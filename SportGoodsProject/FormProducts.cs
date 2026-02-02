using SportGoodsProject.Models;
using SportGoodsProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

			LoadProducts();
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

                        row.Cells["colPhoto"].Value = LoadProductImage(tovar.PhotoUrl);

                       // row.Cells["colInfo"].Value = FormatProductInfo(product);

                        row.Cells["colDiscount"].Value = $"{tovar.Discount}%";
                        row.Cells["colDiscount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                       // ApplyRowStyles(row, product);
                    }

                    //возобновить отрисовку
                    dgvProducts.ResumeLayout();
                    //высота строк по содержимому
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

        private Image LoadProductImage(object photoUrl)
        {
            if(!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;
        }
    }
}