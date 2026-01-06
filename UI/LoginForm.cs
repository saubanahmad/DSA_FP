using System;
using System.Drawing;
using System.Windows.Forms;
using FlightBookingSystem.Services;

namespace FlightBookingSystem.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin123" && txtPass.Text == "admin123")
            {
                AdminForm admin = new AdminForm();
                this.Hide();
                admin.ShowDialog();
                this.Close();
            }
            else
            {
                lblMsg.Text = "Invalid Credentials!";
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
