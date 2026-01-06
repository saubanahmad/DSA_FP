using System;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Data;
using FlightBookingSystem.Core.DataStructures;
using FlightBookingSystem.UI.UIComponents;

namespace FlightBookingSystem.UI
{
    public class frmPassengerManifest : Form
    {
        private CustomLabel lblFlight;
        private CustomComboBox cmbFlights;
        private CustomDataGridView dgvPassengers;

        public frmPassengerManifest()
        {
            InitializeComponent();
            LoadFlights();
            Theme.ApplyToForm(this);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblFlight = new CustomLabel();
            cmbFlights = new CustomComboBox();
            dgvPassengers = new CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPassengers).BeginInit();
            SuspendLayout();
            // 
            // lblFlight
            // 
            lblFlight.Anchor = AnchorStyles.Top;
            lblFlight.AutoSize = true;
            lblFlight.Font = new Font("Segoe UI", 10F);
            lblFlight.ForeColor = Color.FromArgb(248, 250, 252);
            lblFlight.LabelType = LabelType.Body;
            lblFlight.Location = new Point(181, 24);
            lblFlight.Margin = new Padding(2, 0, 2, 0);
            lblFlight.Name = "lblFlight";
            lblFlight.Size = new Size(106, 23);
            lblFlight.TabIndex = 0;
            lblFlight.Text = "Select Flight:";
            // 
            // cmbFlights
            // 
            cmbFlights.Anchor = AnchorStyles.Top;
            cmbFlights.BackColor = Color.FromArgb(30, 41, 59);
            cmbFlights.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFlights.FlatStyle = FlatStyle.Flat;
            cmbFlights.Font = new Font("Segoe UI", 10F);
            cmbFlights.ForeColor = Color.FromArgb(248, 250, 252);
            cmbFlights.FormattingEnabled = true;
            cmbFlights.Location = new Point(292, 22);
            cmbFlights.Margin = new Padding(2, 2, 2, 2);
            cmbFlights.Name = "cmbFlights";
            cmbFlights.Size = new Size(321, 31);
            cmbFlights.TabIndex = 1;
            cmbFlights.SelectedIndexChanged += CmbFlights_SelectedIndexChanged;
            // 
            // dgvPassengers
            // 
            dgvPassengers.AllowUserToAddRows = false;
            dgvPassengers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 55, 72);
            dgvPassengers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPassengers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPassengers.BackgroundColor = Color.FromArgb(15, 23, 42);
            dgvPassengers.BorderStyle = BorderStyle.None;
            dgvPassengers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPassengers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(51, 65, 85);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle2.Padding = new Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPassengers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPassengers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle3.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPassengers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPassengers.EnableHeadersVisualStyles = false;
            dgvPassengers.Font = new Font("Segoe UI", 10F);
            dgvPassengers.GridColor = Color.FromArgb(71, 85, 105);
            dgvPassengers.Location = new Point(24, 64);
            dgvPassengers.Margin = new Padding(2, 2, 2, 2);
            dgvPassengers.MultiSelect = false;
            dgvPassengers.Name = "dgvPassengers";
            dgvPassengers.ReadOnly = true;
            dgvPassengers.RowHeadersVisible = false;
            dgvPassengers.RowHeadersWidth = 62;
            dgvPassengers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPassengers.Size = new Size(752, 376);
            dgvPassengers.TabIndex = 2;
            // 
            // frmPassengerManifest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 464);
            Controls.Add(dgvPassengers);
            Controls.Add(cmbFlights);
            Controls.Add(lblFlight);
            Margin = new Padding(2, 2, 2, 2);
            Name = "frmPassengerManifest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Passenger Manifest";
            WindowState = FormWindowState.Maximized;
            Load += frmPassengerManifest_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPassengers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadFlights()
        {
            cmbFlights.Items.Clear();

            var flights = DbHelper.LoadFlights();
            Node<Flight>? fNode = flights.Head;

            while (fNode != null)
            {
                Flight f = fNode.Data;
                string displayText = $"{f.FlightID} - {f.OriginCode} → {f.DestinationCode} ({f.FlightDate:yyyy-MM-dd HH:mm})";
                cmbFlights.Items.Add(new FlightItem { FlightID = f.FlightID, DisplayText = displayText });
                fNode = fNode.Next;
            }

            cmbFlights.DisplayMember = "DisplayText";
        }

        private void CmbFlights_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbFlights.SelectedItem == null) return;

            FlightItem selectedFlight = (FlightItem)cmbFlights.SelectedItem;
            LoadPassengers(selectedFlight.FlightID);
        }

        private void LoadPassengers(int flightId)
        {
            dgvPassengers.Rows.Clear();
            dgvPassengers.Columns.Clear();

            dgvPassengers.Columns.Add("FirstName", "First Name");
            dgvPassengers.Columns.Add("LastName", "Last Name");
            dgvPassengers.Columns.Add("Age", "Age");
            dgvPassengers.Columns.Add("PassportNumber", "Passport Number");
            dgvPassengers.Columns.Add("Email", "Email");

            var passengers = DbHelper.GetPassengersByFlight(flightId);
            Node<Passenger>? pNode = passengers.Head;

            int count = 0;
            while (pNode != null)
            {
                Passenger p = pNode.Data;
                dgvPassengers.Rows.Add(
                    p.FirstName,
                    p.LastName,
                    p.Age,
                    p.PassportNumber,
                    p.Email
                );
                count++;
                pNode = pNode.Next;
            }

            this.Text = $"Passenger Manifest - {count} passenger(s)";
        }

        // Helper class to store flight info in ComboBox
        private class FlightItem
        {
            public int FlightID { get; set; }
            public string DisplayText { get; set; } = "";
        }

        private void frmPassengerManifest_Load(object sender, EventArgs e)
        {

        }
    }
}
