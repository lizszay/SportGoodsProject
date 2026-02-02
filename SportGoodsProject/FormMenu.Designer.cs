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
            btnBack = new Button();
            lblUserName = new Label();
            btnLogut = new Button();
            panel1 = new Panel();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogut);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(547, 40);
            panelTop.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(67, 97, 238);
            btnBack.Dock = DockStyle.Left;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(0, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 40);
            btnBack.TabIndex = 7;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
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
            btnLogut.Size = new Size(150, 40);
            btnLogut.TabIndex = 5;
            btnLogut.Text = "Выход";
            btnLogut.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(547, 321);
            panel1.TabIndex = 3;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(547, 361);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMenu";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnBack;
        private Label lblUserName;
        private Button btnLogut;
        private Panel panel1;
    }
}