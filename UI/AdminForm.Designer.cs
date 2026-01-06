using FlightBookingSystem.UI.UIComponents;

namespace FlightBookingSystem.UI
{
    partial class AdminForm
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            tabs = new CustomTabControl();
            tabAirport = new TabPage();
            lbl1 = new CustomLabel();
            txtACode = new CustomTextBox();
            lbl2 = new CustomLabel();
            txtAName = new CustomTextBox();
            lbl3 = new CustomLabel();
            txtACity = new CustomTextBox();
            btnAddAirport = new CustomButton();
            btnDeleteAirport = new CustomButton();
            tabRoute = new TabPage();
            lblR1 = new CustomLabel();
            cmbRouteOrigin = new CustomComboBox();
            lblR2 = new CustomLabel();
            cmbRouteDest = new CustomComboBox();
            lblR3 = new CustomLabel();
            txtDist = new CustomTextBox();
            btnAddRoute = new CustomButton();
            tabFlight = new TabPage();
            lblF1 = new CustomLabel();
            cmbFOrigin = new CustomComboBox();
            lblF2 = new CustomLabel();
            cmbFDest = new CustomComboBox();
            lblF3 = new CustomLabel();
            dtpFlight = new CustomDateTimePicker();
            lblF4 = new CustomLabel();
            txtDuration = new CustomTextBox();
            lblF5 = new CustomLabel();
            txtPrice = new CustomTextBox();
            lblF6 = new CustomLabel();
            numTotalSeats = new NumericUpDown();
            btnSchedule = new CustomButton();
            tabReports = new TabPage();
            gridFlights = new CustomDataGridView();
            btnRefresh = new CustomButton();
            customLabel1 = new CustomLabel();
            countrytxt = new CustomTextBox();
            tabs.SuspendLayout();
            tabAirport.SuspendLayout();
            tabRoute.SuspendLayout();
            tabFlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalSeats).BeginInit();
            tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFlights).BeginInit();
            SuspendLayout();
            // 
            // tabs
            // 
            tabs.Controls.Add(tabAirport);
            tabs.Controls.Add(tabRoute);
            tabs.Controls.Add(tabFlight);
            tabs.Controls.Add(tabReports);
            tabs.Dock = DockStyle.Fill;
            tabs.Font = new Font("Segoe UI", 11F);
            tabs.Location = new Point(0, 0);
            tabs.Margin = new Padding(4, 5, 4, 5);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(1142, 1000);
            tabs.TabIndex = 0;
            // 
            // tabAirport
            // 
            tabAirport.BackColor = Color.FromArgb(15, 23, 42);
            tabAirport.Controls.Add(customLabel1);
            tabAirport.Controls.Add(countrytxt);
            tabAirport.Controls.Add(lbl1);
            tabAirport.Controls.Add(txtACode);
            tabAirport.Controls.Add(lbl2);
            tabAirport.Controls.Add(txtAName);
            tabAirport.Controls.Add(lbl3);
            tabAirport.Controls.Add(txtACity);
            tabAirport.Controls.Add(btnAddAirport);
            tabAirport.Controls.Add(btnDeleteAirport);
            tabAirport.ForeColor = Color.FromArgb(248, 250, 252);
            tabAirport.Location = new Point(4, 39);
            tabAirport.Margin = new Padding(4, 5, 4, 5);
            tabAirport.Name = "tabAirport";
            tabAirport.Padding = new Padding(20);
            tabAirport.Size = new Size(1134, 957);
            tabAirport.TabIndex = 0;
            tabAirport.Text = "Manage Airports";
            tabAirport.Click += tabAirport_Click;
            // 
            // lbl1
            // 
            lbl1.Anchor = AnchorStyles.Top;
            lbl1.AutoSize = true;
            lbl1.Font = new Font("Segoe UI", 10F);
            lbl1.ForeColor = Color.FromArgb(248, 250, 252);
            lbl1.LabelType = LabelType.Body;
            lbl1.Location = new Point(308, 137);
            lbl1.Margin = new Padding(4, 0, 4, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(147, 28);
            lbl1.TabIndex = 0;
            lbl1.Text = "Code (e.g. LHE):";
            // 
            // txtACode
            // 
            txtACode.Anchor = AnchorStyles.Top;
            txtACode.BackColor = Color.FromArgb(30, 41, 59);
            txtACode.BorderStyle = BorderStyle.FixedSingle;
            txtACode.Font = new Font("Segoe UI", 10F);
            txtACode.ForeColor = Color.FromArgb(248, 250, 252);
            txtACode.Location = new Point(476, 135);
            txtACode.Margin = new Padding(4, 5, 4, 5);
            txtACode.Name = "txtACode";
            txtACode.Size = new Size(284, 34);
            txtACode.TabIndex = 1;
            // 
            // lbl2
            // 
            lbl2.Anchor = AnchorStyles.Top;
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Segoe UI", 10F);
            lbl2.ForeColor = Color.FromArgb(248, 250, 252);
            lbl2.LabelType = LabelType.Body;
            lbl2.Location = new Point(308, 204);
            lbl2.Margin = new Padding(4, 0, 4, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(68, 28);
            lbl2.TabIndex = 2;
            lbl2.Text = "Name:";
            // 
            // txtAName
            // 
            txtAName.Anchor = AnchorStyles.Top;
            txtAName.BackColor = Color.FromArgb(30, 41, 59);
            txtAName.BorderStyle = BorderStyle.FixedSingle;
            txtAName.Font = new Font("Segoe UI", 10F);
            txtAName.ForeColor = Color.FromArgb(248, 250, 252);
            txtAName.Location = new Point(476, 203);
            txtAName.Margin = new Padding(4, 5, 4, 5);
            txtAName.Name = "txtAName";
            txtAName.Size = new Size(284, 34);
            txtAName.TabIndex = 3;
            // 
            // lbl3
            // 
            lbl3.Anchor = AnchorStyles.Top;
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Segoe UI", 10F);
            lbl3.ForeColor = Color.FromArgb(248, 250, 252);
            lbl3.LabelType = LabelType.Body;
            lbl3.Location = new Point(308, 271);
            lbl3.Margin = new Padding(4, 0, 4, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(50, 28);
            lbl3.TabIndex = 4;
            lbl3.Text = "City:";
            // 
            // txtACity
            // 
            txtACity.Anchor = AnchorStyles.Top;
            txtACity.BackColor = Color.FromArgb(30, 41, 59);
            txtACity.BorderStyle = BorderStyle.FixedSingle;
            txtACity.Font = new Font("Segoe UI", 10F);
            txtACity.ForeColor = Color.FromArgb(248, 250, 252);
            txtACity.Location = new Point(476, 269);
            txtACity.Margin = new Padding(4, 5, 4, 5);
            txtACity.Name = "txtACity";
            txtACity.Size = new Size(284, 34);
            txtACity.TabIndex = 5;
            txtACity.TextChanged += txtACity_TextChanged;
            // 
            // btnAddAirport
            // 
            btnAddAirport.Anchor = AnchorStyles.Top;
            btnAddAirport.BackColor = Color.FromArgb(106, 117, 155);
            btnAddAirport.ButtonType = ButtonType.Primary;
            btnAddAirport.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnAddAirport.FlatAppearance.BorderSize = 0;
            btnAddAirport.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnAddAirport.FlatStyle = FlatStyle.Flat;
            btnAddAirport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddAirport.ForeColor = Color.White;
            btnAddAirport.Location = new Point(476, 401);
            btnAddAirport.Margin = new Padding(4, 5, 4, 5);
            btnAddAirport.Name = "btnAddAirport";
            btnAddAirport.Size = new Size(284, 50);
            btnAddAirport.TabIndex = 6;
            btnAddAirport.Text = "Add Airport";
            btnAddAirport.UseVisualStyleBackColor = false;
            btnAddAirport.Click += BtnAddAirport_Click;
            // 
            // btnDeleteAirport
            // 
            btnDeleteAirport.Anchor = AnchorStyles.Top;
            btnDeleteAirport.BackColor = Color.FromArgb(239, 68, 68);
            btnDeleteAirport.ButtonType = ButtonType.Danger;
            btnDeleteAirport.FlatAppearance.BorderSize = 0;
            btnDeleteAirport.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
            btnDeleteAirport.FlatStyle = FlatStyle.Flat;
            btnDeleteAirport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteAirport.ForeColor = Color.White;
            btnDeleteAirport.Location = new Point(476, 481);
            btnDeleteAirport.Margin = new Padding(4, 5, 4, 5);
            btnDeleteAirport.Name = "btnDeleteAirport";
            btnDeleteAirport.Size = new Size(284, 50);
            btnDeleteAirport.TabIndex = 8;
            btnDeleteAirport.Text = "Delete Airport";
            btnDeleteAirport.UseVisualStyleBackColor = false;
            btnDeleteAirport.Click += BtnDeleteAirport_Click;
            // 
            // tabRoute
            // 
            tabRoute.BackColor = Color.FromArgb(15, 23, 42);
            tabRoute.Controls.Add(lblR1);
            tabRoute.Controls.Add(cmbRouteOrigin);
            tabRoute.Controls.Add(lblR2);
            tabRoute.Controls.Add(cmbRouteDest);
            tabRoute.Controls.Add(lblR3);
            tabRoute.Controls.Add(txtDist);
            tabRoute.Controls.Add(btnAddRoute);
            tabRoute.ForeColor = Color.FromArgb(248, 250, 252);
            tabRoute.Location = new Point(4, 39);
            tabRoute.Margin = new Padding(4, 5, 4, 5);
            tabRoute.Name = "tabRoute";
            tabRoute.Padding = new Padding(20);
            tabRoute.Size = new Size(1134, 957);
            tabRoute.TabIndex = 1;
            tabRoute.Text = "Map Routes";
            // 
            // lblR1
            // 
            lblR1.Anchor = AnchorStyles.Top;
            lblR1.AutoSize = true;
            lblR1.Font = new Font("Segoe UI", 10F);
            lblR1.ForeColor = Color.FromArgb(248, 250, 252);
            lblR1.LabelType = LabelType.Body;
            lblR1.Location = new Point(328, 146);
            lblR1.Margin = new Padding(4, 0, 4, 0);
            lblR1.Name = "lblR1";
            lblR1.Size = new Size(71, 28);
            lblR1.TabIndex = 0;
            lblR1.Text = "Origin:";
            // 
            // cmbRouteOrigin
            // 
            cmbRouteOrigin.Anchor = AnchorStyles.Top;
            cmbRouteOrigin.BackColor = Color.FromArgb(30, 41, 59);
            cmbRouteOrigin.FlatStyle = FlatStyle.Flat;
            cmbRouteOrigin.Font = new Font("Segoe UI", 10F);
            cmbRouteOrigin.ForeColor = Color.FromArgb(248, 250, 252);
            cmbRouteOrigin.FormattingEnabled = true;
            cmbRouteOrigin.Location = new Point(480, 143);
            cmbRouteOrigin.Margin = new Padding(4, 5, 4, 5);
            cmbRouteOrigin.Name = "cmbRouteOrigin";
            cmbRouteOrigin.Size = new Size(298, 36);
            cmbRouteOrigin.TabIndex = 1;
            // 
            // lblR2
            // 
            lblR2.Anchor = AnchorStyles.Top;
            lblR2.AutoSize = true;
            lblR2.Font = new Font("Segoe UI", 10F);
            lblR2.ForeColor = Color.FromArgb(248, 250, 252);
            lblR2.LabelType = LabelType.Body;
            lblR2.Location = new Point(328, 213);
            lblR2.Margin = new Padding(4, 0, 4, 0);
            lblR2.Name = "lblR2";
            lblR2.Size = new Size(116, 28);
            lblR2.TabIndex = 2;
            lblR2.Text = "Destination:";
            // 
            // cmbRouteDest
            // 
            cmbRouteDest.Anchor = AnchorStyles.Top;
            cmbRouteDest.BackColor = Color.FromArgb(30, 41, 59);
            cmbRouteDest.FlatStyle = FlatStyle.Flat;
            cmbRouteDest.Font = new Font("Segoe UI", 10F);
            cmbRouteDest.ForeColor = Color.FromArgb(248, 250, 252);
            cmbRouteDest.FormattingEnabled = true;
            cmbRouteDest.Location = new Point(480, 210);
            cmbRouteDest.Margin = new Padding(4, 5, 4, 5);
            cmbRouteDest.Name = "cmbRouteDest";
            cmbRouteDest.Size = new Size(298, 36);
            cmbRouteDest.TabIndex = 3;
            // 
            // lblR3
            // 
            lblR3.Anchor = AnchorStyles.Top;
            lblR3.AutoSize = true;
            lblR3.Font = new Font("Segoe UI", 10F);
            lblR3.ForeColor = Color.FromArgb(248, 250, 252);
            lblR3.LabelType = LabelType.Body;
            lblR3.Location = new Point(328, 280);
            lblR3.Margin = new Padding(4, 0, 4, 0);
            lblR3.Name = "lblR3";
            lblR3.Size = new Size(134, 28);
            lblR3.TabIndex = 4;
            lblR3.Text = "Distance (km):";
            // 
            // txtDist
            // 
            txtDist.Anchor = AnchorStyles.Top;
            txtDist.BackColor = Color.FromArgb(30, 41, 59);
            txtDist.BorderStyle = BorderStyle.FixedSingle;
            txtDist.Font = new Font("Segoe UI", 10F);
            txtDist.ForeColor = Color.FromArgb(248, 250, 252);
            txtDist.Location = new Point(480, 277);
            txtDist.Margin = new Padding(4, 5, 4, 5);
            txtDist.Name = "txtDist";
            txtDist.Size = new Size(298, 34);
            txtDist.TabIndex = 5;
            txtDist.TextChanged += txtDist_TextChanged;
            // 
            // btnAddRoute
            // 
            btnAddRoute.Anchor = AnchorStyles.Top;
            btnAddRoute.BackColor = Color.FromArgb(106, 117, 155);
            btnAddRoute.ButtonType = ButtonType.Primary;
            btnAddRoute.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnAddRoute.FlatAppearance.BorderSize = 0;
            btnAddRoute.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnAddRoute.FlatStyle = FlatStyle.Flat;
            btnAddRoute.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddRoute.ForeColor = Color.White;
            btnAddRoute.Location = new Point(480, 336);
            btnAddRoute.Margin = new Padding(4, 5, 4, 5);
            btnAddRoute.Name = "btnAddRoute";
            btnAddRoute.Size = new Size(298, 50);
            btnAddRoute.TabIndex = 6;
            btnAddRoute.Text = "Connect (Create Edge)";
            btnAddRoute.UseVisualStyleBackColor = false;
            btnAddRoute.Click += BtnAddRoute_Click;
            // 
            // tabFlight
            // 
            tabFlight.BackColor = Color.FromArgb(15, 23, 42);
            tabFlight.Controls.Add(lblF1);
            tabFlight.Controls.Add(cmbFOrigin);
            tabFlight.Controls.Add(lblF2);
            tabFlight.Controls.Add(cmbFDest);
            tabFlight.Controls.Add(lblF3);
            tabFlight.Controls.Add(dtpFlight);
            tabFlight.Controls.Add(lblF4);
            tabFlight.Controls.Add(txtDuration);
            tabFlight.Controls.Add(lblF5);
            tabFlight.Controls.Add(txtPrice);
            tabFlight.Controls.Add(lblF6);
            tabFlight.Controls.Add(numTotalSeats);
            tabFlight.Controls.Add(btnSchedule);
            tabFlight.ForeColor = Color.FromArgb(248, 250, 252);
            tabFlight.Location = new Point(4, 39);
            tabFlight.Margin = new Padding(4, 5, 4, 5);
            tabFlight.Name = "tabFlight";
            tabFlight.Padding = new Padding(20);
            tabFlight.Size = new Size(1134, 957);
            tabFlight.TabIndex = 2;
            tabFlight.Text = "Schedule Flight";
            // 
            // lblF1
            // 
            lblF1.Anchor = AnchorStyles.Top;
            lblF1.AutoSize = true;
            lblF1.Font = new Font("Segoe UI", 10F);
            lblF1.ForeColor = Color.FromArgb(248, 250, 252);
            lblF1.LabelType = LabelType.Body;
            lblF1.Location = new Point(326, 156);
            lblF1.Margin = new Padding(4, 0, 4, 0);
            lblF1.Name = "lblF1";
            lblF1.Size = new Size(71, 28);
            lblF1.TabIndex = 0;
            lblF1.Text = "Origin:";
            // 
            // cmbFOrigin
            // 
            cmbFOrigin.Anchor = AnchorStyles.Top;
            cmbFOrigin.BackColor = Color.FromArgb(30, 41, 59);
            cmbFOrigin.FlatStyle = FlatStyle.Flat;
            cmbFOrigin.Font = new Font("Segoe UI", 10F);
            cmbFOrigin.ForeColor = Color.FromArgb(248, 250, 252);
            cmbFOrigin.FormattingEnabled = true;
            cmbFOrigin.Location = new Point(491, 153);
            cmbFOrigin.Margin = new Padding(4, 5, 4, 5);
            cmbFOrigin.Name = "cmbFOrigin";
            cmbFOrigin.Size = new Size(284, 36);
            cmbFOrigin.TabIndex = 1;
            // 
            // lblF2
            // 
            lblF2.Anchor = AnchorStyles.Top;
            lblF2.AutoSize = true;
            lblF2.Font = new Font("Segoe UI", 10F);
            lblF2.ForeColor = Color.FromArgb(248, 250, 252);
            lblF2.LabelType = LabelType.Body;
            lblF2.Location = new Point(326, 223);
            lblF2.Margin = new Padding(4, 0, 4, 0);
            lblF2.Name = "lblF2";
            lblF2.Size = new Size(116, 28);
            lblF2.TabIndex = 2;
            lblF2.Text = "Destination:";
            // 
            // cmbFDest
            // 
            cmbFDest.Anchor = AnchorStyles.Top;
            cmbFDest.BackColor = Color.FromArgb(30, 41, 59);
            cmbFDest.FlatStyle = FlatStyle.Flat;
            cmbFDest.Font = new Font("Segoe UI", 10F);
            cmbFDest.ForeColor = Color.FromArgb(248, 250, 252);
            cmbFDest.FormattingEnabled = true;
            cmbFDest.Location = new Point(491, 220);
            cmbFDest.Margin = new Padding(4, 5, 4, 5);
            cmbFDest.Name = "cmbFDest";
            cmbFDest.Size = new Size(284, 36);
            cmbFDest.TabIndex = 3;
            // 
            // lblF3
            // 
            lblF3.Anchor = AnchorStyles.Top;
            lblF3.AutoSize = true;
            lblF3.Font = new Font("Segoe UI", 10F);
            lblF3.ForeColor = Color.FromArgb(248, 250, 252);
            lblF3.LabelType = LabelType.Body;
            lblF3.Location = new Point(326, 290);
            lblF3.Margin = new Padding(4, 0, 4, 0);
            lblF3.Name = "lblF3";
            lblF3.Size = new Size(57, 28);
            lblF3.TabIndex = 4;
            lblF3.Text = "Date:";
            // 
            // dtpFlight
            // 
            dtpFlight.Anchor = AnchorStyles.Top;
            dtpFlight.BackColor = Color.FromArgb(30, 41, 59);
            dtpFlight.CalendarForeColor = Color.FromArgb(248, 250, 252);
            dtpFlight.CalendarMonthBackground = Color.FromArgb(30, 41, 59);
            dtpFlight.CalendarTitleBackColor = Color.FromArgb(51, 65, 85);
            dtpFlight.CalendarTitleForeColor = Color.FromArgb(248, 250, 252);
            dtpFlight.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpFlight.Font = new Font("Segoe UI", 10F);
            dtpFlight.ForeColor = Color.FromArgb(248, 250, 252);
            dtpFlight.Format = DateTimePickerFormat.Custom;
            dtpFlight.Location = new Point(491, 285);
            dtpFlight.Margin = new Padding(4, 5, 4, 5);
            dtpFlight.Name = "dtpFlight";
            dtpFlight.ShowUpDown = true;
            dtpFlight.Size = new Size(284, 34);
            dtpFlight.TabIndex = 5;
            dtpFlight.ValueChanged += dtpFlight_ValueChanged;
            // 
            // lblF4
            // 
            lblF4.Anchor = AnchorStyles.Top;
            lblF4.AutoSize = true;
            lblF4.Font = new Font("Segoe UI", 10F);
            lblF4.ForeColor = Color.FromArgb(248, 250, 252);
            lblF4.LabelType = LabelType.Body;
            lblF4.Location = new Point(326, 356);
            lblF4.Margin = new Padding(4, 0, 4, 0);
            lblF4.Name = "lblF4";
            lblF4.Size = new Size(143, 28);
            lblF4.TabIndex = 6;
            lblF4.Text = "Duration (min):";
            // 
            // txtDuration
            // 
            txtDuration.Anchor = AnchorStyles.Top;
            txtDuration.BackColor = Color.FromArgb(30, 41, 59);
            txtDuration.BorderStyle = BorderStyle.FixedSingle;
            txtDuration.Font = new Font("Segoe UI", 10F);
            txtDuration.ForeColor = Color.FromArgb(248, 250, 252);
            txtDuration.Location = new Point(491, 354);
            txtDuration.Margin = new Padding(4, 5, 4, 5);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(284, 34);
            txtDuration.TabIndex = 7;
            // 
            // lblF5
            // 
            lblF5.Anchor = AnchorStyles.Top;
            lblF5.AutoSize = true;
            lblF5.Font = new Font("Segoe UI", 10F);
            lblF5.ForeColor = Color.FromArgb(248, 250, 252);
            lblF5.LabelType = LabelType.Body;
            lblF5.Location = new Point(326, 423);
            lblF5.Margin = new Padding(4, 0, 4, 0);
            lblF5.Name = "lblF5";
            lblF5.Size = new Size(58, 28);
            lblF5.TabIndex = 8;
            lblF5.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top;
            txtPrice.BackColor = Color.FromArgb(30, 41, 59);
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Font = new Font("Segoe UI", 10F);
            txtPrice.ForeColor = Color.FromArgb(248, 250, 252);
            txtPrice.Location = new Point(491, 421);
            txtPrice.Margin = new Padding(4, 5, 4, 5);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(284, 34);
            txtPrice.TabIndex = 9;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // lblF6
            // 
            lblF6.Anchor = AnchorStyles.Top;
            lblF6.AutoSize = true;
            lblF6.Font = new Font("Segoe UI", 10F);
            lblF6.ForeColor = Color.FromArgb(248, 250, 252);
            lblF6.LabelType = LabelType.Body;
            lblF6.Location = new Point(326, 490);
            lblF6.Margin = new Padding(4, 0, 4, 0);
            lblF6.Name = "lblF6";
            lblF6.Size = new Size(109, 28);
            lblF6.TabIndex = 10;
            lblF6.Text = "Total Seats:";
            // 
            // numTotalSeats
            // 
            numTotalSeats.Anchor = AnchorStyles.Top;
            numTotalSeats.Location = new Point(491, 487);
            numTotalSeats.Margin = new Padding(4, 5, 4, 5);
            numTotalSeats.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numTotalSeats.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTotalSeats.Name = "numTotalSeats";
            numTotalSeats.Size = new Size(284, 37);
            numTotalSeats.TabIndex = 11;
            numTotalSeats.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // btnSchedule
            // 
            btnSchedule.Anchor = AnchorStyles.Top;
            btnSchedule.BackColor = Color.FromArgb(106, 117, 155);
            btnSchedule.ButtonType = ButtonType.Primary;
            btnSchedule.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnSchedule.FlatAppearance.BorderSize = 0;
            btnSchedule.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnSchedule.FlatStyle = FlatStyle.Flat;
            btnSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSchedule.ForeColor = Color.White;
            btnSchedule.Location = new Point(491, 560);
            btnSchedule.Margin = new Padding(4, 5, 4, 5);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(284, 50);
            btnSchedule.TabIndex = 12;
            btnSchedule.Text = "Schedule Flight";
            btnSchedule.UseVisualStyleBackColor = false;
            btnSchedule.Click += BtnSchedule_Click;
            // 
            // tabReports
            // 
            tabReports.BackColor = Color.FromArgb(15, 23, 42);
            tabReports.Controls.Add(gridFlights);
            tabReports.Controls.Add(btnRefresh);
            tabReports.ForeColor = Color.FromArgb(248, 250, 252);
            tabReports.Location = new Point(4, 39);
            tabReports.Margin = new Padding(4, 5, 4, 5);
            tabReports.Name = "tabReports";
            tabReports.Padding = new Padding(20);
            tabReports.Size = new Size(1134, 957);
            tabReports.TabIndex = 3;
            tabReports.Text = "Flight Status Reports";
            // 
            // gridFlights
            // 
            gridFlights.AllowUserToAddRows = false;
            gridFlights.AllowUserToDeleteRows = false;
            gridFlights.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(45, 55, 72);
            gridFlights.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            gridFlights.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gridFlights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridFlights.BackgroundColor = Color.FromArgb(15, 23, 42);
            gridFlights.BorderStyle = BorderStyle.None;
            gridFlights.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridFlights.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle8.Padding = new Padding(10);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            gridFlights.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            gridFlights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle9.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            gridFlights.DefaultCellStyle = dataGridViewCellStyle9;
            gridFlights.EnableHeadersVisualStyles = false;
            gridFlights.Font = new Font("Segoe UI", 10F);
            gridFlights.GridColor = Color.FromArgb(71, 85, 105);
            gridFlights.Location = new Point(20, 97);
            gridFlights.Margin = new Padding(4, 5, 4, 5);
            gridFlights.MultiSelect = false;
            gridFlights.Name = "gridFlights";
            gridFlights.ReadOnly = true;
            gridFlights.RowHeadersVisible = false;
            gridFlights.RowHeadersWidth = 62;
            gridFlights.RowTemplate.Height = 25;
            gridFlights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridFlights.Size = new Size(1091, 890);
            gridFlights.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(106, 117, 155);
            btnRefresh.ButtonType = ButtonType.Primary;
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(20, 20);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(1094, 68);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh Status";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // customLabel1
            // 
            customLabel1.Anchor = AnchorStyles.Top;
            customLabel1.AutoSize = true;
            customLabel1.Font = new Font("Segoe UI", 10F);
            customLabel1.ForeColor = Color.FromArgb(248, 250, 252);
            customLabel1.LabelType = LabelType.Body;
            customLabel1.Location = new Point(308, 336);
            customLabel1.Margin = new Padding(4, 0, 4, 0);
            customLabel1.Name = "customLabel1";
            customLabel1.Size = new Size(86, 28);
            customLabel1.TabIndex = 9;
            customLabel1.Text = "Country:";
            // 
            // countrytxt
            // 
            countrytxt.Anchor = AnchorStyles.Top;
            countrytxt.BackColor = Color.FromArgb(30, 41, 59);
            countrytxt.BorderStyle = BorderStyle.FixedSingle;
            countrytxt.Font = new Font("Segoe UI", 10F);
            countrytxt.ForeColor = Color.FromArgb(248, 250, 252);
            countrytxt.Location = new Point(476, 334);
            countrytxt.Margin = new Padding(4, 5, 4, 5);
            countrytxt.Name = "countrytxt";
            countrytxt.Size = new Size(284, 34);
            countrytxt.TabIndex = 10;
            countrytxt.TextChanged += countrytxt_TextChanged;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 1000);
            Controls.Add(tabs);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Control Panel - Airline Management";
            WindowState = FormWindowState.Maximized;
            Load += AdminForm_Load;
            tabs.ResumeLayout(false);
            tabAirport.ResumeLayout(false);
            tabAirport.PerformLayout();
            tabRoute.ResumeLayout(false);
            tabRoute.PerformLayout();
            tabFlight.ResumeLayout(false);
            tabFlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalSeats).EndInit();
            tabReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFlights).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CustomTabControl tabs;
        private System.Windows.Forms.TabPage tabAirport;
        private CustomLabel lbl1;
        private CustomTextBox txtACode;
        private CustomLabel lbl2;
        private CustomTextBox txtAName;
        private CustomLabel lbl3;
        private CustomTextBox txtACity;
        private CustomButton btnAddAirport;
        private CustomButton btnDeleteAirport;
        private System.Windows.Forms.TabPage tabRoute;
        private CustomLabel lblR1;
        private CustomComboBox cmbRouteOrigin;
        private CustomLabel lblR2;
        private CustomComboBox cmbRouteDest;
        private CustomLabel lblR3;
        private CustomTextBox txtDist;
        private CustomButton btnAddRoute;
        private System.Windows.Forms.TabPage tabFlight;
        private CustomLabel lblF1;
        private CustomComboBox cmbFOrigin;
        private CustomLabel lblF2;
        private CustomComboBox cmbFDest;
        private CustomLabel lblF3;
        private CustomDateTimePicker dtpFlight;
        private CustomLabel lblF4;
        private CustomTextBox txtDuration;
        private CustomLabel lblF5;
        private CustomTextBox txtPrice;
        private CustomLabel lblF6;
        private System.Windows.Forms.NumericUpDown numTotalSeats;
        private CustomButton btnSchedule;
        private System.Windows.Forms.TabPage tabReports;
        private CustomDataGridView gridFlights;
        private CustomButton btnRefresh;
        private CustomLabel customLabel1;
        private CustomTextBox countrytxt;
    }
}
