using System;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.Data;

namespace FlightBookingSystem.UI
{
    public partial class frmManageAirports : Form
    {
        public frmManageAirports()
        {
            InitializeComponent();
            Theme.ApplyToForm(this);
            LoadAirportGrid();
        }
        private void LoadAirportGrid()
        {
            try
            {
                // Clear existing columns and rows
                dgvAirports.Columns.Clear();
                dgvAirports.Rows.Clear();

                // Add columns
                dgvAirports.Columns.Add("AirportCode", "Airport Code");
                dgvAirports.Columns.Add("AirportName", "Airport Name");
                dgvAirports.Columns.Add("City", "City");
                dgvAirports.Columns.Add("Country", "Country");
                dgvAirports.Columns.Add("RouteCount", "Routes Count");

                // Add Delete button column
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "Delete";
                btnDelete.HeaderText = "Action";
                btnDelete.Text = "Delete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.DefaultCellStyle.BackColor = Color.FromArgb(239, 68, 68);
                btnDelete.DefaultCellStyle.ForeColor = Color.White;
                btnDelete.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 38, 38);
                dgvAirports.Columns.Add(btnDelete);

                // Set column widths
                dgvAirports.Columns["AirportCode"].Width = 120;
                dgvAirports.Columns["AirportName"].Width = 250;
                dgvAirports.Columns["City"].Width = 150;
                dgvAirports.Columns["Country"].Width = 120;
                dgvAirports.Columns["RouteCount"].Width = 100;
                dgvAirports.Columns["Delete"].Width = 100;

                // Load data from database
                var airports = DbHelper.GetAirportsWithRouteCounts();

                foreach (var airport in airports)
                {
                    dgvAirports.Rows.Add(
                        airport.AirportCode,
                        airport.AirportName,
                        airport.City,
                        airport.Country,
                        airport.RouteCount
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading airports: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvAirports_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvAirports.Columns["Delete"].Index)
                return;

            try
            {
                string airportCode = dgvAirports.Rows[e.RowIndex].Cells["AirportCode"].Value.ToString() ?? "";
                string airportName = dgvAirports.Rows[e.RowIndex].Cells["AirportName"].Value.ToString() ?? "";
                int routeCount = Convert.ToInt32(dgvAirports.Rows[e.RowIndex].Cells["RouteCount"].Value);

                string message = $"Are you sure you want to delete airport '{airportCode} - {airportName}'?\n\n" +
                                $"This will permanently delete:\n" +
                                $"- {routeCount} route(s) connected to this airport\n" +
                                $"- All flights originating from or going to this airport\n" +
                                $"- All bookings for those flights\n" +
                                $"- All tickets for those bookings\n\n" +
                                $"This action CANNOT be undone!";

                var result = MessageBox.Show(message, "Confirm Cascade Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                bool success = DbHelper.DeleteAirportCascade(airportCode, out string errorMessage);

                if (success)
                {
                    MessageBox.Show($"Airport '{airportCode}' and all related data deleted successfully!", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadAirportGrid();
                    
                    FlightService.Network.RemoveAirport(airportCode);
                }
                else
                {
                    MessageBox.Show($"Failed to delete airport: {errorMessage}", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during delete operation: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadAirportGrid();
            MessageBox.Show("Grid refreshed successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
