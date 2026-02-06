using SportGoodsProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SportGoodsProject
{
    public partial class FormOrders : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormOrders(User user, bool guest)
        {
            InitializeComponent();

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 75;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDeliveryDate = new DataGridViewTextBoxColumn();
            colDeliveryDate.Name = "colDeliveryDate";
            colDeliveryDate.FillWeight = 25;
            colDeliveryDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.AddRange(
            [
                colInfo, colDeliveryDate
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                using (var db = new SportGoodsDbContext())
                {

                    var orders = db.Orders
                        .Where(w => w.IdUser == CurrentUser.Id)
                        .Include(i => i.OrderItem)
                            //подгрузка влож.нав.св-в
                            .ThenInclude(t => t.Tovar)
                        .Include(i => i.Status)
                        .Include(i => i.PickupPoint)
                        .OrderByDescending(o => o.OrderDate) // Сортируем по дате заказа
                        .ToList();

                    dgvOrders.SuspendLayout();
                    dgvOrders.Rows.Clear();

                    foreach (var order in orders)
                    {
                        int rowIndex = dgvOrders.Rows.Add();
                        var row = dgvOrders.Rows[rowIndex];

                        row.Cells["colInfo"].Value = FormatOrderInfo(order);
                        row.Cells["colDeliveryDate"].Value = order.DeliveryDate;
                    }

                    //возобновить отрисовку
                    dgvOrders.ResumeLayout();
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

        private string FormatOrderInfo(Order order)
        {
            string items = "";

            if (order.OrderItems != null)
            {
                foreach (var i in order.OrderItems)
                {
                    if (i.Tovar != null)
                    {
                        items += $"{i.Tovar.Article}, {i.CountOrder}, ";
                    }
                    else
                    {
                        items += $"Товар не найден, {i.CountOrder}, ";
                    }
                }
                if (items.Length > 2)
                {
                    items = items.Remove(items.Length - 2);
                }
            }
            else
            {
                items = "Товары не указаны";
            }

            return $"Артикул заказа: {items}\n" +
                $"Статус заказа: {order.Status.StatusName}\n" +
                $"Адрес пункта выдачи: {order.PickupPoint.FullAdress}\n" +
                $"Номер телефона пвз: {order.PickupPoint.PhoneNumber}\n" +
                $"Дата заказа: {order.OrderDate}";
        }

        private void BtnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort; // Специальный результат для "Назад"
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
