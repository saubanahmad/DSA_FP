using System;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.Data;
using FlightBookingSystem.Core.DataStructures;
using FlightBookingSystem.UI.UIComponents;

namespace FlightBookingSystem.UI
{
    public class frmFlightStatusReport : Form
    {
        private CustomDataGridView dgvFlights;
        private CustomButton btnRefresh;

        public frmFlightStatusReport()
        {
            InitializeComponent();
            LoadFlights();
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvFlights = new CustomDataGridView();
            btnRefresh = new CustomButton();
            ((System.ComponentModel.ISupportInitialize)dgvFlights).BeginInit();
            SuspendLayout();
            // 
            // dgvFlights
            // 
            dgvFlights.AllowUserToAddRows = false;
            dgvFlights.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 55, 72);
            dgvFlights.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvFlights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFlights.BackgroundColor = Color.FromArgb(15, 23, 42);
            dgvFlights.BorderStyle = BorderStyle.None;
            dgvFlights.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFlights.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Padding = new Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFlights.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvFlights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle3.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvFlights.DefaultCellStyle = dataGridViewCellStyle3;
            dgvFlights.Dock = DockStyle.Fill;
            dgvFlights.EnableHeadersVisualStyles = false;
            dgvFlights.Font = new Font("Segoe UI", 10F);
            dgvFlights.GridColor = Color.FromArgb(71, 85, 105);
            dgvFlights.Location = new Point(0, 65);
            dgvFlights.MultiSelect = false;
            dgvFlights.Name = "dgvFlights";
            dgvFlights.ReadOnly = true;
            dgvFlights.RowHeadersVisible = false;
            dgvFlights.RowHeadersWidth = 62;
            dgvFlights.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFlights.Size = new Size(900, 485);
            dgvFlights.TabIndex = 1;
            dgvFlights.CellContentClick += DgvFlights_CellContentClick;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(106, 117, 155);
            btnRefresh.ButtonType = ButtonType.Primary;
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(900, 65);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // frmFlightStatusReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(dgvFlights);
            Controls.Add(btnRefresh);
            Name = "frmFlightStatusReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Flight Status Report";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvFlights).EndInit();
            ResumeLayout(false);
        }

        private void LoadFlights()
        {
            // Clear existing data
            dgvFlights.Rows.Clear();
            dgvFlights.Columns.Clear();
            
            // Setup columns
            dgvFlights.Columns.Add("FlightID", "Flight ID");
            dgvFlights.Columns["FlightID"].Visible = false; // Hidden for reference
            
            dgvFlights.Columns.Add("Route", "Route");
            dgvFlights.Columns.Add("Date", "Flight Date");
            dgvFlights.Columns.Add("Duration", "Duration (min)");
            dgvFlights.Columns.Add("Price", "Price");
            dgvFlights.Columns.Add("Seats", "Seats Available");
            dgvFlights.Columns.Add("Status", "Status");
            
            // Feature 6: Add Delete button column
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.HeaderText = "Action";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            dgvFlights.Columns.Add(btnDelete);
            
            // Load flights from database
            DbHelper.UpdateFlightStatuses();
            var flights = DbHelper.LoadFlights();
            Node<Flight>? fNode = flights.Head;
            
            while (fNode != null)
            {
                Flight f = fNode.Data;
                dgvFlights.Rows.Add(
                    f.FlightID,
                    $"{f.OriginCode} → {f.DestinationCode}",
                    f.FlightDate.ToString("yyyy-MM-dd HH:mm"),
                    f.DurationMinutes,
                    f.Price.ToString("C"),
                    $"{f.SeatsAvailable}/{f.TotalSeats}",
                    f.Status
                );
                fNode = fNode.Next;
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadFlights();
        }

        private void DgvFlights_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            if (dgvFlights.Columns[e.ColumnIndex].Name == "Delete")
            {
                int flightId = Convert.ToInt32(dgvFlights.Rows[e.RowIndex].Cells["FlightID"].Value);
                string route = dgvFlights.Rows[e.RowIndex].Cells["Route"].Value.ToString() ?? "";
                
                var result = MessageBox.Show(
                    $"Delete flight {route}?\\n\\nThis will also delete all associated bookings and tickets.\\n\\nThis action cannot be undone!",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DbHelper.DeleteFlight(flightId);
                        
                        FlightService.RefreshFlights();
                        
                        MessageBox.Show("Flight deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFlights();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting flight: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
