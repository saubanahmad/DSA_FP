using System;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.Data;
using FlightBookingSystem.Core.DataStructures;
using FlightBookingSystem.UI.UIComponents;

namespace FlightBookingSystem.UI
{
    public class frmAdminBookingApprovals : Form
    {
        private CustomLabel lblFilter;
        private CustomComboBox cmbFlightFilter;
        private CustomButton btnRefresh;
        private CustomDataGridView dgvBookings;

        public frmAdminBookingApprovals()
        {
            InitializeComponent();
            LoadFlightFilter();
            LoadPendingBookings(null);
            Theme.ApplyToForm(this);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblFilter = new CustomLabel();
            cmbFlightFilter = new CustomComboBox();
            btnRefresh = new CustomButton();
            dgvBookings = new CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 10F);
            lblFilter.ForeColor = Color.FromArgb(248, 250, 252);
            lblFilter.LabelType = LabelType.Body;
            lblFilter.Location = new Point(30, 27);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(142, 28);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Filter by Flight:";
            // 
            // cmbFlightFilter
            // 
            cmbFlightFilter.BackColor = Color.FromArgb(30, 41, 59);
            cmbFlightFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFlightFilter.FlatStyle = FlatStyle.Flat;
            cmbFlightFilter.Font = new Font("Segoe UI", 10F);
            cmbFlightFilter.ForeColor = Color.FromArgb(248, 250, 252);
            cmbFlightFilter.FormattingEnabled = true;
            cmbFlightFilter.Location = new Point(201, 24);
            cmbFlightFilter.Name = "cmbFlightFilter";
            cmbFlightFilter.Size = new Size(400, 36);
            cmbFlightFilter.TabIndex = 1;
            cmbFlightFilter.SelectedIndexChanged += CmbFlightFilter_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(106, 117, 155);
            btnRefresh.ButtonType = ButtonType.Primary;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(629, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 46);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 55, 72);
            dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookings.BackgroundColor = Color.FromArgb(15, 23, 42);
            dgvBookings.BorderStyle = BorderStyle.None;
            dgvBookings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBookings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Padding = new Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle3.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBookings.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBookings.EnableHeadersVisualStyles = false;
            dgvBookings.Font = new Font("Segoe UI", 10F);
            dgvBookings.GridColor = Color.FromArgb(71, 85, 105);
            dgvBookings.Location = new Point(30, 80);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.RowHeadersVisible = false;
            dgvBookings.RowHeadersWidth = 62;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(1140, 520);
            dgvBookings.TabIndex = 3;
            dgvBookings.CellContentClick += DgvBookings_CellContentClick;
            // 
            // frmAdminBookingApprovals
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 630);
            Controls.Add(dgvBookings);
            Controls.Add(btnRefresh);
            Controls.Add(cmbFlightFilter);
            Controls.Add(lblFilter);
            Name = "frmAdminBookingApprovals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin - Booking Approvals";
            WindowState = FormWindowState.Maximized;
            Load += frmAdminBookingApprovals_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadFlightFilter()
        {
            cmbFlightFilter.Items.Clear();
            cmbFlightFilter.Items.Add(new FlightFilterItem { FlightID = null, DisplayText = "All Flights" });

            // Load all flights
            var flights = DbHelper.LoadFlights();
            Node<Flight>? fNode = flights.Head;

            while (fNode != null)
            {
                Flight f = fNode.Data;
                string displayText = $"{f.FlightID} - {f.OriginCode} → {f.DestinationCode} ({f.FlightDate:yyyy-MM-dd})";
                cmbFlightFilter.Items.Add(new FlightFilterItem { FlightID = f.FlightID, DisplayText = displayText });
                fNode = fNode.Next;
            }

            cmbFlightFilter.DisplayMember = "DisplayText";
            cmbFlightFilter.SelectedIndex = 0;
        }

        private void LoadPendingBookings(int? flightId)
        {
            // Clear existing data
            dgvBookings.Rows.Clear();
            dgvBookings.Columns.Clear();

            // Setup columns
            dgvBookings.Columns.Add("BookingID", "Booking ID");
            dgvBookings.Columns["BookingID"].Visible = false; // Hidden column for reference

            dgvBookings.Columns.Add("PNR", "PNR");
            dgvBookings.Columns.Add("Flight", "Flight");
            dgvBookings.Columns.Add("Date", "Flight Date");
            dgvBookings.Columns.Add("BookingDate", "Booking Date");
            dgvBookings.Columns.Add("Status", "Status");

            // Add button columns
            DataGridViewButtonColumn btnConfirm = new DataGridViewButtonColumn();
            btnConfirm.Name = "Confirm";
            btnConfirm.HeaderText = "Action";
            btnConfirm.Text = "Confirm";
            btnConfirm.UseColumnTextForButtonValue = true;
            dgvBookings.Columns.Add(btnConfirm);

            DataGridViewButtonColumn btnCancel = new DataGridViewButtonColumn();
            btnCancel.Name = "Cancel";
            btnCancel.HeaderText = "";
            btnCancel.Text = "Cancel";
            btnCancel.UseColumnTextForButtonValue = true;
            dgvBookings.Columns.Add(btnCancel);

            // Load pending bookings
            var bookings = DbHelper.GetPendingBookings(flightId);
            Node<Booking>? bNode = bookings.Head;

            int count = 0;
            while (bNode != null)
            {
                Booking b = bNode.Data;
                if (b.FlightDetails != null)
                {
                    dgvBookings.Rows.Add(
                        b.BookingID,
                        b.PNR,
                        $"{b.FlightDetails.OriginCode} → {b.FlightDetails.DestinationCode}",
                        b.FlightDetails.FlightDate.ToString("yyyy-MM-dd HH:mm"),
                        b.BookingDate.ToString("yyyy-MM-dd"),
                        b.Status
                    );
                    count++;
                }
                bNode = bNode.Next;
            }

            this.Text = $"Admin - Booking Approvals ({count} pending)";
        }

        private void CmbFlightFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbFlightFilter.SelectedItem == null) return;

            FlightFilterItem selected = (FlightFilterItem)cmbFlightFilter.SelectedItem;
            LoadPendingBookings(selected.FlightID);
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            if (cmbFlightFilter.SelectedItem == null) return;

            FlightFilterItem selected = (FlightFilterItem)cmbFlightFilter.SelectedItem;
            LoadPendingBookings(selected.FlightID);
        }

        private void DgvBookings_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int bookingId = Convert.ToInt32(dgvBookings.Rows[e.RowIndex].Cells["BookingID"].Value);
            string pnr = dgvBookings.Rows[e.RowIndex].Cells["PNR"].Value.ToString() ?? "";

            if (dgvBookings.Columns[e.ColumnIndex].Name == "Confirm")
            {
                // Confirm booking
                var result = MessageBox.Show(
                    $"Confirm booking {pnr}?",
                    "Confirm Booking",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    DbHelper.UpdateBookingStatus(bookingId, "Confirmed");
                    MessageBox.Show("Booking confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnRefresh_Click(null, EventArgs.Empty);
                }
            }
            else if (dgvBookings.Columns[e.ColumnIndex].Name == "Cancel")
            {
                // Cancel booking
                var result = MessageBox.Show(
                    $"Cancel booking {pnr}? This will delete the booking and restore seats.",
                    "Cancel Booking",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Cancel booking and restore seats
                    bool success = DbHelper.CancelBooking(pnr, out string errorMessage);

                    if (success)
                    {
                        MessageBox.Show("Booking cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnRefresh_Click(null, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to cancel booking: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private class FlightFilterItem
        {
            public int? FlightID { get; set; }
            public string DisplayText { get; set; } = "";
        }

        private void frmAdminBookingApprovals_Load(object sender, EventArgs e)
        {

        }
    }
}
