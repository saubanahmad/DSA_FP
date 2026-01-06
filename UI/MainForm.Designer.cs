using FlightBookingSystem.UI.UIComponents;

namespace FlightBookingSystem.UI
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new CustomPanel();
            btnviewmap = new CustomButton();
            btnAdmin = new CustomButton();
            tabs = new CustomTabControl();
            tabSearch = new TabPage();
            lblO = new CustomLabel();
            txtSearchOrigin = new CustomTextBox();
            lstSuggestionsO = new CustomListBox();
            lblD = new CustomLabel();
            txtSearchDest = new CustomTextBox();
            lstSuggestionsD = new CustomListBox();
            lblDate = new CustomLabel();
            dtpSearch = new CustomDateTimePicker();
            btnSearchDate = new CustomButton();
            btnSortPrice = new CustomButton();
            btnGoToBook = new CustomButton();
            gridResults = new CustomDataGridView();
            tabBook = new TabPage();
            undolastBTN = new CustomButton();
            lblSelectedFlight = new CustomLabel();
            grpPass = new CustomGroupBox();
            customLabel1 = new CustomLabel();
            textEmail = new CustomTextBox();
            lblPName = new CustomLabel();
            txtPassName = new CustomTextBox();
            lblPAge = new CustomLabel();
            txtPassAge = new CustomTextBox();
            lblPPass = new CustomLabel();
            txtPassPassport = new CustomTextBox();
            btnAddPass = new CustomButton();
            lstPassengers = new CustomListBox();
            btnConfirmBook = new CustomButton();
            tabTicket = new TabPage();
            customButton1 = new CustomButton();
            lblT = new CustomLabel();
            txtCheckPNR = new CustomTextBox();
            btnGetTicket = new CustomButton();
            webTicket = new WebBrowser();
            pnlHeader.SuspendLayout();
            tabs.SuspendLayout();
            tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
            tabBook.SuspendLayout();
            grpPass.SuspendLayout();
            tabTicket.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
            pnlHeader.Controls.Add(btnviewmap);
            pnlHeader.Controls.Add(btnAdmin);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12, 12, 12, 12);
            pnlHeader.PanelType = PanelType.Header;
            pnlHeader.Size = new Size(1369, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnviewmap
            // 
            btnviewmap.BackColor = Color.FromArgb(185, 212, 241);
            btnviewmap.ButtonType = ButtonType.Ghost;
            btnviewmap.FlatAppearance.BorderSize = 0;
            btnviewmap.FlatAppearance.MouseOverBackColor = Color.White;
            btnviewmap.FlatStyle = FlatStyle.Flat;
            btnviewmap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnviewmap.ForeColor = Color.FromArgb(33, 39, 61);
            btnviewmap.Location = new Point(14, 12);
            btnviewmap.Margin = new Padding(2, 2, 2, 2);
            btnviewmap.Name = "btnviewmap";
            btnviewmap.Size = new Size(180, 56);
            btnviewmap.TabIndex = 2;
            btnviewmap.Text = "View Map";
            btnviewmap.UseVisualStyleBackColor = false;
            btnviewmap.Click += btnviewmap_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.BackColor = Color.FromArgb(185, 212, 241);
            btnAdmin.ButtonType = ButtonType.Ghost;
            btnAdmin.Dock = DockStyle.Right;
            btnAdmin.FlatAppearance.BorderColor = Color.FromArgb(71, 85, 105);
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.FlatAppearance.MouseOverBackColor = Color.White;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdmin.ForeColor = Color.FromArgb(33, 39, 61);
            btnAdmin.Location = new Point(1151, 12);
            btnAdmin.Margin = new Padding(11, 14, 11, 14);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(206, 56);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "Admin Dashboard";
            btnAdmin.UseVisualStyleBackColor = false;
            btnAdmin.Click += BtnAdmin_Click;
            // 
            // tabs
            // 
            tabs.Controls.Add(tabSearch);
            tabs.Controls.Add(tabBook);
            tabs.Controls.Add(tabTicket);
            tabs.Dock = DockStyle.Fill;
            tabs.Font = new Font("Segoe UI", 11F);
            tabs.Location = new Point(0, 80);
            tabs.Margin = new Padding(3, 4, 3, 4);
            tabs.Name = "tabs";
            tabs.Padding = new Point(20, 8);
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(1369, 758);
            tabs.TabIndex = 1;
            // 
            // tabSearch
            // 
            tabSearch.BackColor = Color.FromArgb(15, 23, 42);
            tabSearch.Controls.Add(lblO);
            tabSearch.Controls.Add(txtSearchOrigin);
            tabSearch.Controls.Add(lstSuggestionsO);
            tabSearch.Controls.Add(lblD);
            tabSearch.Controls.Add(txtSearchDest);
            tabSearch.Controls.Add(lstSuggestionsD);
            tabSearch.Controls.Add(lblDate);
            tabSearch.Controls.Add(dtpSearch);
            tabSearch.Controls.Add(btnSearchDate);
            tabSearch.Controls.Add(btnSortPrice);
            tabSearch.Controls.Add(btnGoToBook);
            tabSearch.Controls.Add(gridResults);
            tabSearch.ForeColor = Color.FromArgb(248, 250, 252);
            tabSearch.Location = new Point(4, 44);
            tabSearch.Margin = new Padding(3, 4, 3, 4);
            tabSearch.Name = "tabSearch";
            tabSearch.Padding = new Padding(16, 16, 16, 16);
            tabSearch.Size = new Size(1363, 712);
            tabSearch.TabIndex = 0;
            tabSearch.Text = "Search Flights";
            tabSearch.Click += tabSearch_Click;
            // 
            // lblO
            // 
            lblO.Anchor = AnchorStyles.Top;
            lblO.AutoSize = true;
            lblO.Font = new Font("Segoe UI", 10F);
            lblO.ForeColor = Color.FromArgb(248, 250, 252);
            lblO.LabelType = LabelType.Body;
            lblO.Location = new Point(214, 31);
            lblO.Name = "lblO";
            lblO.Size = new Size(61, 23);
            lblO.TabIndex = 0;
            lblO.Text = "Origin:";
            lblO.Click += lblO_Click;
            // 
            // txtSearchOrigin
            // 
            txtSearchOrigin.Anchor = AnchorStyles.Top;
            txtSearchOrigin.BackColor = Color.FromArgb(30, 41, 59);
            txtSearchOrigin.BorderStyle = BorderStyle.FixedSingle;
            txtSearchOrigin.Font = new Font("Segoe UI", 10F);
            txtSearchOrigin.ForeColor = Color.FromArgb(248, 250, 252);
            txtSearchOrigin.Location = new Point(278, 30);
            txtSearchOrigin.Margin = new Padding(3, 4, 3, 4);
            txtSearchOrigin.Name = "txtSearchOrigin";
            txtSearchOrigin.Size = new Size(216, 30);
            txtSearchOrigin.TabIndex = 1;
            txtSearchOrigin.TextChanged += TxtSearchOrigin_TextChanged;
            // 
            // lstSuggestionsO
            // 
            lstSuggestionsO.Anchor = AnchorStyles.Top;
            lstSuggestionsO.BackColor = Color.FromArgb(30, 41, 59);
            lstSuggestionsO.BorderStyle = BorderStyle.FixedSingle;
            lstSuggestionsO.Font = new Font("Segoe UI", 10F);
            lstSuggestionsO.ForeColor = Color.FromArgb(248, 250, 252);
            lstSuggestionsO.FormattingEnabled = true;
            lstSuggestionsO.ItemHeight = 23;
            lstSuggestionsO.Location = new Point(278, 65);
            lstSuggestionsO.Margin = new Padding(3, 4, 3, 4);
            lstSuggestionsO.Name = "lstSuggestionsO";
            lstSuggestionsO.Size = new Size(216, 25);
            lstSuggestionsO.TabIndex = 2;
            lstSuggestionsO.Visible = false;
            lstSuggestionsO.Click += LstSuggestionsO_Click;
            // 
            // lblD
            // 
            lblD.Anchor = AnchorStyles.Top;
            lblD.AutoSize = true;
            lblD.Font = new Font("Segoe UI", 10F);
            lblD.ForeColor = Color.FromArgb(248, 250, 252);
            lblD.LabelType = LabelType.Body;
            lblD.Location = new Point(519, 31);
            lblD.Name = "lblD";
            lblD.Size = new Size(106, 23);
            lblD.TabIndex = 3;
            lblD.Text = "Destination: ";
            lblD.Click += lblD_Click;
            // 
            // txtSearchDest
            // 
            txtSearchDest.Anchor = AnchorStyles.Top;
            txtSearchDest.BackColor = Color.FromArgb(30, 41, 59);
            txtSearchDest.BorderStyle = BorderStyle.FixedSingle;
            txtSearchDest.Font = new Font("Segoe UI", 10F);
            txtSearchDest.ForeColor = Color.FromArgb(248, 250, 252);
            txtSearchDest.Location = new Point(622, 30);
            txtSearchDest.Margin = new Padding(3, 4, 3, 4);
            txtSearchDest.Name = "txtSearchDest";
            txtSearchDest.Size = new Size(216, 30);
            txtSearchDest.TabIndex = 4;
            txtSearchDest.TextChanged += TxtSearchDest_TextChanged;
            // 
            // lstSuggestionsD
            // 
            lstSuggestionsD.Anchor = AnchorStyles.Top;
            lstSuggestionsD.BackColor = Color.FromArgb(30, 41, 59);
            lstSuggestionsD.BorderStyle = BorderStyle.FixedSingle;
            lstSuggestionsD.Font = new Font("Segoe UI", 10F);
            lstSuggestionsD.ForeColor = Color.FromArgb(248, 250, 252);
            lstSuggestionsD.FormattingEnabled = true;
            lstSuggestionsD.ItemHeight = 23;
            lstSuggestionsD.Location = new Point(622, 65);
            lstSuggestionsD.Margin = new Padding(3, 4, 3, 4);
            lstSuggestionsD.Name = "lstSuggestionsD";
            lstSuggestionsD.Size = new Size(216, 25);
            lstSuggestionsD.TabIndex = 5;
            lstSuggestionsD.Visible = false;
            lstSuggestionsD.Click += LstSuggestionsD_Click;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.ForeColor = Color.FromArgb(248, 250, 252);
            lblDate.LabelType = LabelType.Body;
            lblDate.Location = new Point(872, 31);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(50, 23);
            lblDate.TabIndex = 6;
            lblDate.Text = "Date:";
            // 
            // dtpSearch
            // 
            dtpSearch.Anchor = AnchorStyles.Top;
            dtpSearch.BackColor = Color.FromArgb(30, 41, 59);
            dtpSearch.CalendarForeColor = Color.FromArgb(30, 41, 59);
            dtpSearch.CalendarMonthBackground = Color.FromArgb(30, 41, 59);
            dtpSearch.CalendarTitleBackColor = Color.FromArgb(51, 65, 85);
            dtpSearch.CalendarTitleForeColor = Color.FromArgb(30, 41, 59);
            dtpSearch.Font = new Font("Segoe UI", 10F);
            dtpSearch.ForeColor = Color.FromArgb(248, 250, 252);
            dtpSearch.Format = DateTimePickerFormat.Short;
            dtpSearch.Location = new Point(924, 30);
            dtpSearch.Margin = new Padding(3, 4, 3, 4);
            dtpSearch.Name = "dtpSearch";
            dtpSearch.Size = new Size(216, 30);
            dtpSearch.TabIndex = 7;
            dtpSearch.ValueChanged += dtpSearch_ValueChanged;
            // 
            // btnSearchDate
            // 
            btnSearchDate.Anchor = AnchorStyles.Top;
            btnSearchDate.BackColor = Color.FromArgb(106, 117, 155);
            btnSearchDate.ButtonType = ButtonType.Primary;
            btnSearchDate.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnSearchDate.FlatAppearance.BorderSize = 0;
            btnSearchDate.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnSearchDate.FlatStyle = FlatStyle.Flat;
            btnSearchDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearchDate.ForeColor = Color.White;
            btnSearchDate.Location = new Point(214, 147);
            btnSearchDate.Margin = new Padding(3, 4, 3, 4);
            btnSearchDate.Name = "btnSearchDate";
            btnSearchDate.Size = new Size(171, 61);
            btnSearchDate.TabIndex = 8;
            btnSearchDate.Text = "Search by Date";
            btnSearchDate.UseVisualStyleBackColor = false;
            btnSearchDate.Click += BtnSearchDate_Click;
            // 
            // btnSortPrice
            // 
            btnSortPrice.Anchor = AnchorStyles.Top;
            btnSortPrice.BackColor = Color.FromArgb(106, 117, 155);
            btnSortPrice.ButtonType = ButtonType.Primary;
            btnSortPrice.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnSortPrice.FlatAppearance.BorderSize = 0;
            btnSortPrice.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnSortPrice.FlatStyle = FlatStyle.Flat;
            btnSortPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSortPrice.ForeColor = Color.White;
            btnSortPrice.Location = new Point(392, 147);
            btnSortPrice.Margin = new Padding(3, 4, 3, 4);
            btnSortPrice.Name = "btnSortPrice";
            btnSortPrice.Size = new Size(171, 61);
            btnSortPrice.TabIndex = 9;
            btnSortPrice.Text = "Sort Cheapest";
            btnSortPrice.UseVisualStyleBackColor = false;
            btnSortPrice.Click += BtnSortPrice_Click;
            // 
            // btnGoToBook
            // 
            btnGoToBook.Anchor = AnchorStyles.Top;
            btnGoToBook.BackColor = Color.FromArgb(34, 197, 94);
            btnGoToBook.ButtonType = ButtonType.Success;
            btnGoToBook.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnGoToBook.FlatAppearance.BorderSize = 0;
            btnGoToBook.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
            btnGoToBook.FlatStyle = FlatStyle.Flat;
            btnGoToBook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGoToBook.ForeColor = Color.White;
            btnGoToBook.Location = new Point(968, 147);
            btnGoToBook.Margin = new Padding(3, 4, 3, 4);
            btnGoToBook.Name = "btnGoToBook";
            btnGoToBook.Size = new Size(171, 61);
            btnGoToBook.TabIndex = 10;
            btnGoToBook.Text = "Book";
            btnGoToBook.UseVisualStyleBackColor = false;
            btnGoToBook.Click += BtnGoToBook_Click;
            // 
            // gridResults
            // 
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.AllowUserToResizeColumns = false;
            gridResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 55, 72);
            gridResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridResults.Anchor = AnchorStyles.Top;
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridResults.BackgroundColor = Color.FromArgb(15, 23, 42);
            gridResults.BorderStyle = BorderStyle.None;
            gridResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Padding = new Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            gridResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            gridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle3.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridResults.DefaultCellStyle = dataGridViewCellStyle3;
            gridResults.EnableHeadersVisualStyles = false;
            gridResults.Font = new Font("Segoe UI", 10F);
            gridResults.GridColor = Color.FromArgb(71, 85, 105);
            gridResults.Location = new Point(214, 216);
            gridResults.Margin = new Padding(3, 4, 3, 4);
            gridResults.MultiSelect = false;
            gridResults.Name = "gridResults";
            gridResults.ReadOnly = true;
            gridResults.RowHeadersVisible = false;
            gridResults.RowHeadersWidth = 62;
            gridResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridResults.Size = new Size(925, 554);
            gridResults.TabIndex = 11;
            gridResults.CellContentClick += gridResults_CellContentClick;
            // 
            // tabBook
            // 
            tabBook.BackColor = Color.FromArgb(15, 23, 42);
            tabBook.Controls.Add(undolastBTN);
            tabBook.Controls.Add(lblSelectedFlight);
            tabBook.Controls.Add(grpPass);
            tabBook.Controls.Add(lstPassengers);
            tabBook.Controls.Add(btnConfirmBook);
            tabBook.ForeColor = Color.FromArgb(248, 250, 252);
            tabBook.Location = new Point(4, 44);
            tabBook.Margin = new Padding(3, 4, 3, 4);
            tabBook.Name = "tabBook";
            tabBook.Padding = new Padding(16, 16, 16, 16);
            tabBook.Size = new Size(1363, 712);
            tabBook.TabIndex = 1;
            tabBook.Text = "Book Flight";
            // 
            // undolastBTN
            // 
            undolastBTN.Anchor = AnchorStyles.Top;
            undolastBTN.BackColor = Color.FromArgb(251, 146, 60);
            undolastBTN.ButtonType = ButtonType.Warning;
            undolastBTN.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            undolastBTN.FlatAppearance.BorderSize = 0;
            undolastBTN.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 88, 12);
            undolastBTN.FlatStyle = FlatStyle.Flat;
            undolastBTN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            undolastBTN.ForeColor = Color.White;
            undolastBTN.Location = new Point(729, 343);
            undolastBTN.Margin = new Padding(3, 4, 3, 4);
            undolastBTN.Name = "undolastBTN";
            undolastBTN.Size = new Size(343, 35);
            undolastBTN.TabIndex = 4;
            undolastBTN.Text = "Undo Last Passenger";
            undolastBTN.UseVisualStyleBackColor = false;
            undolastBTN.Click += undolastBTN_Click;
            // 
            // lblSelectedFlight
            // 
            lblSelectedFlight.Anchor = AnchorStyles.Top;
            lblSelectedFlight.AutoSize = true;
            lblSelectedFlight.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSelectedFlight.ForeColor = Color.FromArgb(248, 250, 252);
            lblSelectedFlight.LabelType = LabelType.SubHeader;
            lblSelectedFlight.Location = new Point(338, 24);
            lblSelectedFlight.Name = "lblSelectedFlight";
            lblSelectedFlight.Size = new Size(221, 32);
            lblSelectedFlight.TabIndex = 0;
            lblSelectedFlight.Text = "No Flight Selected";
            // 
            // grpPass
            // 
            grpPass.Anchor = AnchorStyles.Top;
            grpPass.Controls.Add(customLabel1);
            grpPass.Controls.Add(textEmail);
            grpPass.Controls.Add(lblPName);
            grpPass.Controls.Add(txtPassName);
            grpPass.Controls.Add(lblPAge);
            grpPass.Controls.Add(txtPassAge);
            grpPass.Controls.Add(lblPPass);
            grpPass.Controls.Add(txtPassPassport);
            grpPass.Controls.Add(btnAddPass);
            grpPass.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            grpPass.ForeColor = Color.FromArgb(248, 250, 252);
            grpPass.Location = new Point(338, 70);
            grpPass.Margin = new Padding(3, 4, 3, 4);
            grpPass.Name = "grpPass";
            grpPass.Padding = new Padding(3, 4, 3, 4);
            grpPass.Size = new Size(343, 309);
            grpPass.TabIndex = 1;
            grpPass.TabStop = false;
            grpPass.Text = "Add Passengers";
            grpPass.Enter += grpPass_Enter;
            // 
            // customLabel1
            // 
            customLabel1.AutoSize = true;
            customLabel1.Font = new Font("Segoe UI", 10F);
            customLabel1.ForeColor = Color.FromArgb(248, 250, 252);
            customLabel1.LabelType = LabelType.Body;
            customLabel1.Location = new Point(23, 194);
            customLabel1.Name = "customLabel1";
            customLabel1.Size = new Size(55, 23);
            customLabel1.TabIndex = 7;
            customLabel1.Text = "Email:";
            customLabel1.Click += customLabel1_Click;
            // 
            // textEmail
            // 
            textEmail.BackColor = Color.FromArgb(30, 41, 59);
            textEmail.BorderStyle = BorderStyle.FixedSingle;
            textEmail.Font = new Font("Segoe UI", 10F);
            textEmail.ForeColor = Color.FromArgb(248, 250, 252);
            textEmail.Location = new Point(114, 193);
            textEmail.Margin = new Padding(3, 4, 3, 4);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(205, 30);
            textEmail.TabIndex = 8;
            textEmail.TextChanged += textEmail_TextChanged;
            // 
            // lblPName
            // 
            lblPName.AutoSize = true;
            lblPName.Font = new Font("Segoe UI", 10F);
            lblPName.ForeColor = Color.FromArgb(248, 250, 252);
            lblPName.LabelType = LabelType.Body;
            lblPName.Location = new Point(23, 40);
            lblPName.Name = "lblPName";
            lblPName.Size = new Size(60, 23);
            lblPName.TabIndex = 0;
            lblPName.Text = "Name:";
            // 
            // txtPassName
            // 
            txtPassName.BackColor = Color.FromArgb(30, 41, 59);
            txtPassName.BorderStyle = BorderStyle.FixedSingle;
            txtPassName.Font = new Font("Segoe UI", 10F);
            txtPassName.ForeColor = Color.FromArgb(248, 250, 252);
            txtPassName.Location = new Point(114, 40);
            txtPassName.Margin = new Padding(3, 4, 3, 4);
            txtPassName.Name = "txtPassName";
            txtPassName.Size = new Size(205, 30);
            txtPassName.TabIndex = 1;
            // 
            // lblPAge
            // 
            lblPAge.AutoSize = true;
            lblPAge.Font = new Font("Segoe UI", 10F);
            lblPAge.ForeColor = Color.FromArgb(248, 250, 252);
            lblPAge.LabelType = LabelType.Body;
            lblPAge.Location = new Point(23, 94);
            lblPAge.Name = "lblPAge";
            lblPAge.Size = new Size(44, 23);
            lblPAge.TabIndex = 2;
            lblPAge.Text = "Age:";
            // 
            // txtPassAge
            // 
            txtPassAge.BackColor = Color.FromArgb(30, 41, 59);
            txtPassAge.BorderStyle = BorderStyle.FixedSingle;
            txtPassAge.Font = new Font("Segoe UI", 10F);
            txtPassAge.ForeColor = Color.FromArgb(248, 250, 252);
            txtPassAge.Location = new Point(114, 94);
            txtPassAge.Margin = new Padding(3, 4, 3, 4);
            txtPassAge.Name = "txtPassAge";
            txtPassAge.Size = new Size(205, 30);
            txtPassAge.TabIndex = 3;
            // 
            // lblPPass
            // 
            lblPPass.AutoSize = true;
            lblPPass.Font = new Font("Segoe UI", 10F);
            lblPPass.ForeColor = Color.FromArgb(248, 250, 252);
            lblPPass.LabelType = LabelType.Body;
            lblPPass.Location = new Point(23, 146);
            lblPPass.Name = "lblPPass";
            lblPPass.Size = new Size(78, 23);
            lblPPass.TabIndex = 4;
            lblPPass.Text = "Passport:";
            // 
            // txtPassPassport
            // 
            txtPassPassport.BackColor = Color.FromArgb(30, 41, 59);
            txtPassPassport.BorderStyle = BorderStyle.FixedSingle;
            txtPassPassport.Font = new Font("Segoe UI", 10F);
            txtPassPassport.ForeColor = Color.FromArgb(248, 250, 252);
            txtPassPassport.Location = new Point(114, 146);
            txtPassPassport.Margin = new Padding(3, 4, 3, 4);
            txtPassPassport.Name = "txtPassPassport";
            txtPassPassport.Size = new Size(205, 30);
            txtPassPassport.TabIndex = 5;
            // 
            // btnAddPass
            // 
            btnAddPass.BackColor = Color.FromArgb(106, 117, 155);
            btnAddPass.ButtonType = ButtonType.Primary;
            btnAddPass.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnAddPass.FlatAppearance.BorderSize = 0;
            btnAddPass.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnAddPass.FlatStyle = FlatStyle.Flat;
            btnAddPass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddPass.ForeColor = Color.White;
            btnAddPass.Location = new Point(66, 242);
            btnAddPass.Margin = new Padding(3, 4, 3, 4);
            btnAddPass.Name = "btnAddPass";
            btnAddPass.Size = new Size(205, 39);
            btnAddPass.TabIndex = 6;
            btnAddPass.Text = "Add";
            btnAddPass.UseVisualStyleBackColor = false;
            btnAddPass.Click += BtnAddPass_Click;
            // 
            // lstPassengers
            // 
            lstPassengers.Anchor = AnchorStyles.Top;
            lstPassengers.BackColor = Color.FromArgb(30, 41, 59);
            lstPassengers.BorderStyle = BorderStyle.FixedSingle;
            lstPassengers.Font = new Font("Segoe UI", 10F);
            lstPassengers.ForeColor = Color.FromArgb(248, 250, 252);
            lstPassengers.FormattingEnabled = true;
            lstPassengers.ItemHeight = 23;
            lstPassengers.Location = new Point(728, 86);
            lstPassengers.Margin = new Padding(3, 4, 3, 4);
            lstPassengers.Name = "lstPassengers";
            lstPassengers.Size = new Size(344, 278);
            lstPassengers.TabIndex = 2;
            lstPassengers.SelectedIndexChanged += lstPassengers_SelectedIndexChanged;
            // 
            // btnConfirmBook
            // 
            btnConfirmBook.Anchor = AnchorStyles.Top;
            btnConfirmBook.BackColor = Color.FromArgb(34, 197, 94);
            btnConfirmBook.ButtonType = ButtonType.Success;
            btnConfirmBook.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
            btnConfirmBook.FlatAppearance.BorderSize = 0;
            btnConfirmBook.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
            btnConfirmBook.FlatStyle = FlatStyle.Flat;
            btnConfirmBook.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConfirmBook.ForeColor = Color.White;
            btnConfirmBook.Location = new Point(587, 402);
            btnConfirmBook.Margin = new Padding(3, 4, 3, 4);
            btnConfirmBook.Name = "btnConfirmBook";
            btnConfirmBook.Size = new Size(242, 48);
            btnConfirmBook.TabIndex = 3;
            btnConfirmBook.Text = "Confirm Booking";
            btnConfirmBook.UseVisualStyleBackColor = false;
            btnConfirmBook.Click += BtnConfirmBook_Click;
            // 
            // tabTicket
            // 
            tabTicket.BackColor = Color.FromArgb(15, 23, 42);
            tabTicket.Controls.Add(customButton1);
            tabTicket.Controls.Add(lblT);
            tabTicket.Controls.Add(txtCheckPNR);
            tabTicket.Controls.Add(btnGetTicket);
            tabTicket.Controls.Add(webTicket);
            tabTicket.ForeColor = Color.FromArgb(248, 250, 252);
            tabTicket.Location = new Point(4, 44);
            tabTicket.Margin = new Padding(3, 4, 3, 4);
            tabTicket.Name = "tabTicket";
            tabTicket.Padding = new Padding(16, 16, 16, 16);
            tabTicket.Size = new Size(1363, 712);
            tabTicket.TabIndex = 2;
            tabTicket.Text = "My Ticket";
            // 
            // customButton1
            // 
            customButton1.Anchor = AnchorStyles.Top;
            customButton1.BackColor = Color.FromArgb(106, 117, 155);
            customButton1.ButtonType = ButtonType.Primary;
            customButton1.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            customButton1.ForeColor = Color.White;
            customButton1.Location = new Point(968, 578);
            customButton1.Margin = new Padding(3, 4, 3, 4);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(190, 53);
            customButton1.TabIndex = 4;
            customButton1.Text = "Manage Booking";
            customButton1.UseVisualStyleBackColor = false;
            customButton1.Click += customButton1_Click;
            // 
            // lblT
            // 
            lblT.Anchor = AnchorStyles.Top;
            lblT.AutoSize = true;
            lblT.Font = new Font("Segoe UI", 10F);
            lblT.ForeColor = Color.FromArgb(248, 250, 252);
            lblT.LabelType = LabelType.Body;
            lblT.Location = new Point(458, 22);
            lblT.Name = "lblT";
            lblT.Size = new Size(92, 23);
            lblT.TabIndex = 0;
            lblT.Text = "Enter PNR:";
            lblT.Click += lblT_Click;
            // 
            // txtCheckPNR
            // 
            txtCheckPNR.Anchor = AnchorStyles.Top;
            txtCheckPNR.BackColor = Color.FromArgb(30, 41, 59);
            txtCheckPNR.BorderStyle = BorderStyle.FixedSingle;
            txtCheckPNR.Font = new Font("Segoe UI", 10F);
            txtCheckPNR.ForeColor = Color.FromArgb(248, 250, 252);
            txtCheckPNR.Location = new Point(547, 20);
            txtCheckPNR.Margin = new Padding(3, 4, 3, 4);
            txtCheckPNR.Name = "txtCheckPNR";
            txtCheckPNR.Size = new Size(208, 30);
            txtCheckPNR.TabIndex = 1;
            // 
            // btnGetTicket
            // 
            btnGetTicket.Anchor = AnchorStyles.Top;
            btnGetTicket.BackColor = Color.FromArgb(106, 117, 155);
            btnGetTicket.ButtonType = ButtonType.Primary;
            btnGetTicket.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnGetTicket.FlatAppearance.BorderSize = 0;
            btnGetTicket.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnGetTicket.FlatStyle = FlatStyle.Flat;
            btnGetTicket.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGetTicket.ForeColor = Color.White;
            btnGetTicket.Location = new Point(762, 15);
            btnGetTicket.Margin = new Padding(3, 4, 3, 4);
            btnGetTicket.Name = "btnGetTicket";
            btnGetTicket.Size = new Size(114, 38);
            btnGetTicket.TabIndex = 2;
            btnGetTicket.Text = "View Ticket";
            btnGetTicket.UseVisualStyleBackColor = false;
            btnGetTicket.Click += BtnGetTicket_Click;
            // 
            // webTicket
            // 
            webTicket.Anchor = AnchorStyles.Top;
            webTicket.Location = new Point(198, 78);
            webTicket.Margin = new Padding(3, 4, 3, 4);
            webTicket.MinimumSize = new Size(23, 26);
            webTicket.Name = "webTicket";
            webTicket.Size = new Size(960, 477);
            webTicket.TabIndex = 3;
            webTicket.DocumentCompleted += webTicket_DocumentCompleted;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(1369, 838);
            Controls.Add(tabs);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Flight Booking System - Book Your Journey";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            pnlHeader.ResumeLayout(false);
            tabs.ResumeLayout(false);
            tabSearch.ResumeLayout(false);
            tabSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridResults).EndInit();
            tabBook.ResumeLayout(false);
            tabBook.PerformLayout();
            grpPass.ResumeLayout(false);
            grpPass.PerformLayout();
            tabTicket.ResumeLayout(false);
            tabTicket.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomPanel pnlHeader;
        private CustomButton btnAdmin;
        private CustomTabControl tabs;
        private System.Windows.Forms.TabPage tabSearch;
        private CustomLabel lblO;
        private CustomTextBox txtSearchOrigin;
        private CustomListBox lstSuggestionsO;
        private CustomLabel lblD;
        private CustomTextBox txtSearchDest;
        private CustomListBox lstSuggestionsD;
        private CustomLabel lblDate;
        private CustomDateTimePicker dtpSearch;
        private CustomButton btnSearchDate;
        private CustomButton btnSortPrice;
        private CustomButton btnGoToBook;
        private CustomDataGridView gridResults;
        private System.Windows.Forms.TabPage tabBook;
        private CustomLabel lblSelectedFlight;
        private CustomGroupBox grpPass;
        private CustomLabel lblPName;
        private CustomTextBox txtPassName;
        private CustomLabel lblPAge;
        private CustomTextBox txtPassAge;
        private CustomLabel lblPPass;
        private CustomTextBox txtPassPassport;
        private CustomButton btnAddPass;
        private CustomListBox lstPassengers;
        private CustomButton btnConfirmBook;
        private System.Windows.Forms.TabPage tabTicket;
        private CustomLabel lblT;
        private CustomTextBox txtCheckPNR;
        private CustomButton btnGetTicket;
        private System.Windows.Forms.WebBrowser webTicket;
        private CustomButton undolastBTN;
        private CustomButton customButton1;
        private CustomButton btnviewmap;
        private CustomLabel customLabel1;
        private CustomTextBox textEmail;
    }
}
