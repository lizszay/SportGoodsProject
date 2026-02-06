namespace SportGoodsProject
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblUserName = new Label();
            btnLogut = new Button();
            pnlButtons = new Panel();
            btnOrders = new Button();
            btnProducts = new Button();
            panelTop.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogut);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(0, 0, 0, 10);
            panelTop.Size = new Size(547, 40);
            panelTop.TabIndex = 2;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Location = new Point(352, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 19);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "label1";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogut
            // 
            btnLogut.BackColor = Color.FromArgb(67, 97, 238);
            btnLogut.Dock = DockStyle.Right;
            btnLogut.FlatAppearance.BorderSize = 0;
            btnLogut.FlatStyle = FlatStyle.Flat;
            btnLogut.ForeColor = Color.White;
            btnLogut.Location = new Point(397, 0);
            btnLogut.Name = "btnLogut";
            btnLogut.Size = new Size(150, 30);
            btnLogut.TabIndex = 5;
            btnLogut.Text = "Выход";
            btnLogut.UseVisualStyleBackColor = false;
            btnLogut.Click += BtnLogut_Click;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnOrders);
            pnlButtons.Controls.Add(btnProducts);
            pnlButtons.Dock = DockStyle.Fill;
            pnlButtons.Location = new Point(0, 40);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(547, 321);
            pnlButtons.TabIndex = 3;
            // 
            // btnOrders
            // 
            btnOrders.Anchor = AnchorStyles.None;
            btnOrders.BackColor = Color.FromArgb(233, 245, 255);
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.Location = new Point(198, 179);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(150, 30);
            btnOrders.TabIndex = 1;
            btnOrders.Text = "Заказы";
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += BtnOrders_Click;
            // 
            // btnProducts
            // 
            btnProducts.Anchor = AnchorStyles.None;
            btnProducts.BackColor = Color.FromArgb(233, 245, 255);
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.Location = new Point(198, 111);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(150, 30);
            btnProducts.TabIndex = 0;
            btnProducts.Text = "Продукты";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += BtnProducts_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(547, 361);
            Controls.Add(pnlButtons);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMenu";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblUserName;
        private Button btnLogut;
        private Panel pnlButtons;
        private Button btnOrders;
        private Button btnProducts;
    }
}