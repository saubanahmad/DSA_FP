namespace FlightBookingSystem.UI
{
    partial class frmManageAirports
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
            lblTitle = new UIComponents.CustomLabel();
            dgvAirports = new DataGridView();
            btnRefresh = new UIComponents.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(dgvAirports)).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(16, 185, 129);
            lblTitle.LabelType = UIComponents.LabelType.Header;
            lblTitle.Location = new Point(300, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Airports";
            // 
            // dgvAirports
            // 
            dgvAirports.AllowUserToAddRows = false;
            dgvAirports.AllowUserToDeleteRows = false;
            dgvAirports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAirports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAirports.BackgroundColor = Color.FromArgb(15, 23, 42);
            dgvAirports.BorderStyle = BorderStyle.None;
            dgvAirports.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(16, 185, 129);
            dgvAirports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAirports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAirports.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(16, 185, 129);
            dgvAirports.ColumnHeadersHeight = 40;
            dgvAirports.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvAirports.DefaultCellStyle.ForeColor = Color.FromArgb(248, 250, 252);
            dgvAirports.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 65, 85);
            dgvAirports.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAirports.EnableHeadersVisualStyles = false;
            dgvAirports.GridColor = Color.FromArgb(51, 65, 85);
            dgvAirports.Location = new Point(30, 80);
            dgvAirports.Name = "dgvAirports";
            dgvAirports.ReadOnly = true;
            dgvAirports.RowHeadersVisible = false;
            dgvAirports.RowTemplate.Height = 35;
            dgvAirports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAirports.Size = new Size(840, 400);
            dgvAirports.TabIndex = 1;
            dgvAirports.CellContentClick += DgvAirports_CellContentClick;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom;
            btnRefresh.BackColor = Color.FromArgb(106, 117, 155);
            btnRefresh.ButtonType = UIComponents.ButtonType.Primary;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(380, 500);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh Grid";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // frmManageAirports
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 560);
            Controls.Add(btnRefresh);
            Controls.Add(dgvAirports);
            Controls.Add(lblTitle);
            Name = "frmManageAirports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Airport Management";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(dgvAirports)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UIComponents.CustomLabel lblTitle;
        private DataGridView dgvAirports;
        private UIComponents.CustomButton btnRefresh;
    }
}
