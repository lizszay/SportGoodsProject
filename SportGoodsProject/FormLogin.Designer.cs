namespace SportGoodsProject
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pbLogo = new PictureBox();
            pnMain = new Panel();
            btnGuest = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            lbLogin = new Label();
            txtLogin = new TextBox();
            lbPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            pnMain.SuspendLayout();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(133, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(100, 100);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // pnMain
            // 
            pnMain.Anchor = AnchorStyles.None;
            pnMain.Controls.Add(btnGuest);
            pnMain.Controls.Add(btnLogin);
            pnMain.Controls.Add(txtPassword);
            pnMain.Controls.Add(lbLogin);
            pnMain.Controls.Add(txtLogin);
            pnMain.Controls.Add(lbPassword);
            pnMain.Location = new Point(22, 118);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(341, 231);
            pnMain.TabIndex = 1;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.FromArgb(233, 245, 255);
            btnGuest.FlatAppearance.BorderSize = 0;
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.Location = new Point(90, 191);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(150, 26);
            btnGuest.TabIndex = 5;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += BtnGuest_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(67, 97, 238);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(90, 155);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 26);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(40, 116);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 26);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lbLogin
            // 
            lbLogin.AutoSize = true;
            lbLogin.Location = new Point(139, 13);
            lbLogin.Name = "lbLogin";
            lbLogin.Size = new Size(52, 19);
            lbLogin.TabIndex = 2;
            lbLogin.Text = "Логин";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(40, 45);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 26);
            txtLogin.TabIndex = 1;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(136, 84);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(58, 19);
            lbPassword.TabIndex = 0;
            lbPassword.Text = "Пароль";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 361);
            Controls.Add(pnMain);
            Controls.Add(pbLogo);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            pnMain.ResumeLayout(false);
            pnMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Panel pnMain;
        private Button btnGuest;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label lbLogin;
        private TextBox txtLogin;
        private Label lbPassword;
    }
}