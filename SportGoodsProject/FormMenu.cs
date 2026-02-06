using SportGoodsProject.Models;

namespace SportGoodsProject
{
    public partial class FormMenu : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormMenu(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;

            if (IsGuest)
            {
                btnOrders.Visible = false;
            }
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close(); 
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void BtnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
