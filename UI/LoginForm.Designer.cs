using FlightBookingSystem.UI.UIComponents;

namespace FlightBookingSystem.UI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlCard = new CustomPanel();
            lblTitle = new CustomLabel();
            lblMsg = new CustomLabel();
            lblSubtitle = new CustomLabel();
            lblUser = new CustomLabel();
            txtUser = new CustomTextBox();
            lblPass = new CustomLabel();
            txtPass = new CustomTextBox();
            btnLogin = new CustomButton();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pnlCard.BackColor = Color.FromArgb(51, 65, 85);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblMsg);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblUser);
            pnlCard.Controls.Add(txtUser);
            pnlCard.Controls.Add(lblPass);
            pnlCard.Controls.Add(txtPass);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Location = new Point(133, 170);
            pnlCard.Margin = new Padding(4, 5, 4, 5);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(20);
            pnlCard.PanelType = PanelType.Card;
            pnlCard.Size = new Size(714, 622);
            pnlCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(248, 250, 252);
            lblTitle.LabelType = LabelType.Header;
            lblTitle.Location = new Point(56, 50);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(600, 82);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Admin Dashboard";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // lblMsg
            // 
            lblMsg.Font = new Font("Segoe UI", 10F);
            lblMsg.ForeColor = Color.FromArgb(248, 250, 252);
            lblMsg.LabelType = LabelType.Body;
            lblMsg.Location = new Point(56, 598);
            lblMsg.Margin = new Padding(4, 0, 4, 0);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(600, 50);
            lblMsg.TabIndex = 7;
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.LabelType = LabelType.Muted;
            lblSubtitle.Location = new Point(58, 132);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(600, 42);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Sign in to access the admin dashboard";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.FromArgb(248, 250, 252);
            lblUser.LabelType = LabelType.Body;
            lblUser.Location = new Point(58, 218);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(99, 28);
            lblUser.TabIndex = 2;
            lblUser.Text = "Username";
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.FromArgb(30, 41, 59);
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.ForeColor = Color.FromArgb(248, 250, 252);
            txtUser.Location = new Point(58, 258);
            txtUser.Margin = new Padding(4, 5, 4, 5);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(600, 34);
            txtUser.TabIndex = 3;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.ForeColor = Color.FromArgb(248, 250, 252);
            lblPass.LabelType = LabelType.Body;
            lblPass.Location = new Point(58, 350);
            lblPass.Margin = new Padding(4, 0, 4, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(93, 28);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password";
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(30, 41, 59);
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 10F);
            txtPass.ForeColor = Color.FromArgb(248, 250, 252);
            txtPass.Location = new Point(58, 392);
            txtPass.Margin = new Padding(4, 5, 4, 5);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.Size = new Size(600, 34);
            txtPass.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(106, 117, 155);
            btnLogin.ButtonType = ButtonType.Primary;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(58, 500);
            btnLogin.Margin = new Padding(4, 5, 4, 5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(600, 82);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1000, 1000);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Flight Booking System - Admin Login";
            WindowState = FormWindowState.Maximized;
            Load += LoginForm_Load;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomPanel pnlCard;
        private CustomLabel lblTitle;
        private CustomLabel lblSubtitle;
        private CustomTextBox txtUser;
        private CustomTextBox txtPass;
        private CustomButton btnLogin;
        private CustomLabel lblUser;
        private CustomLabel lblPass;
        private CustomLabel lblMsg;
    }
}
