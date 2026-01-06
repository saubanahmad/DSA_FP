using System;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.Data;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.UI
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            cmbFOrigin.SelectedIndexChanged += CmbFOrigin_SelectedIndexChanged;
            InitializeNavigation();
            LoadComboData();
        }

        private void InitializeNavigation()
        {
            // Panel for Top Buttons
            var pnlHeader = new UIComponents.CustomPanel();
            pnlHeader.PanelType = UIComponents.PanelType.Header;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;

            // Button: Flight Map
            var btnGraph = new UIComponents.CustomButton();
            btnGraph.ButtonType = UIComponents.ButtonType.Ghost;
            btnGraph.Text = "Flight Network Map";
            btnGraph.Size = new System.Drawing.Size(180, 40);
            btnGraph.Location = new System.Drawing.Point(15, 10);
            btnGraph.Click += (s, e) => { new frmAirportGraph().Show(); };

            // Button: Status Report
            var btnReport = new UIComponents.CustomButton();
            btnReport.ButtonType = UIComponents.ButtonType.Ghost;
            btnReport.Text = "Route Status";
            btnReport.Size = new System.Drawing.Size(180, 40);
            btnReport.Location = new System.Drawing.Point(205, 10);
            btnReport.Click += (s, e) => { new frmFlightStatusReport().Show(); };

            // Button: Approve Bookings (NEW - Feature 9)
            var btnApproveBookings = new UIComponents.CustomButton();
            btnApproveBookings.ButtonType = UIComponents.ButtonType.Ghost;
            btnApproveBookings.Text = "Approve Bookings";
            btnApproveBookings.Size = new System.Drawing.Size(180, 40);
            btnApproveBookings.Location = new System.Drawing.Point(395, 10);
            btnApproveBookings.Click += BtnApproveBookings_Click;

            // Button: Passenger Manifest (NEW - Feature 7)
            var btnManifest = new UIComponents.CustomButton();
            btnManifest.ButtonType = UIComponents.ButtonType.Ghost;
            btnManifest.Text = "Passenger Manifest";
            btnManifest.Size = new System.Drawing.Size(180, 40);
            btnManifest.Location = new System.Drawing.Point(585, 10);
            btnManifest.Click += BtnManifest_Click;

            // Button: Manage Airports (NEW - Requirement 2)
            var btnManageAirports = new UIComponents.CustomButton();
            btnManageAirports.ButtonType = UIComponents.ButtonType.Ghost;
            btnManageAirports.Text = "Manage Airports";
            btnManageAirports.Size = new System.Drawing.Size(180, 40);
            btnManageAirports.Location = new System.Drawing.Point(775, 10);
            btnManageAirports.Click += BtnManageAirports_Click;

            //button: Undo Button
            var logoutBTN = new UIComponents.CustomButton();
            logoutBTN.ButtonType = UIComponents.ButtonType.Ghost;
            logoutBTN.Text = "Logout";
            logoutBTN.Size = new System.Drawing.Size(180, 40);
            logoutBTN.Location = new System.Drawing.Point(965, 10);
            logoutBTN.Click += UNDOButton_Click;

            pnlHeader.Controls.Add(btnGraph);
            pnlHeader.Controls.Add(btnReport);
            pnlHeader.Controls.Add(btnApproveBookings);
            pnlHeader.Controls.Add(btnManifest);
            pnlHeader.Controls.Add(btnManageAirports);
            pnlHeader.Controls.Add(logoutBTN);

            this.Controls.Add(pnlHeader);
            pnlHeader.SendToBack();
        }

        private void UNDOButton_Click(object? sender, EventArgs e)
        {
            this.Hide();
            frmViewTicket a = new frmViewTicket();
            a.Show();
        }

        private void LoadComboData()
        {
            var list = DbHelper.LoadAirports();
            cmbRouteOrigin.Items.Clear(); cmbRouteDest.Items.Clear();
            cmbFOrigin.Items.Clear(); cmbFDest.Items.Clear();

            Node<Airport>? n = list.Head;
            while (n != null)
            {
                string item = n.Data.AirportCode;
                cmbRouteOrigin.Items.Add(item);
                cmbRouteDest.Items.Add(item);
                cmbFOrigin.Items.Add(item);
                cmbFDest.Items.Add(item);
                n = n.Next;
            }
        }

        private void LoadGrid()
        {
            gridFlights.Columns.Clear();
            gridFlights.Columns.Add("Id", "ID");
            gridFlights.Columns.Add("Route", "Route");
            gridFlights.Columns.Add("Date", "Date");
            gridFlights.Columns.Add("Status", "Status");

            DbHelper.UpdateFlightStatuses();
            FlightService.RefreshFlights();

            InOrderGrid(FlightService.FlightSchedule.Root);
        }

        private void InOrderGrid(FlightNode? r)
        {
            if (r == null) return;
            InOrderGrid(r.Left);
            gridFlights.Rows.Add(r.Data.FlightID, $"{r.Data.OriginCode}-{r.Data.DestinationCode}", r.Data.FlightDate, r.Data.Status);
            InOrderGrid(r.Right);
        }

        private void BtnAddAirport_Click(object? sender, EventArgs e)
        {
            Airport a = new Airport { AirportCode = txtACode.Text, AirportName = txtAName.Text, City = txtACity.Text, Country = countrytxt.Text };
            DbHelper.AddAirport(a);

            FlightService.AirportLookup.Insert(a.AirportCode, $"{a.AirportCode}-{a.AirportName}");
            FlightService.Network.AddAirport(a.AirportCode);

            MessageBox.Show("Airport Added!");
            LoadComboData();
        }

        private void BtnAddRoute_Click(object? sender, EventArgs e)
        {
            string o = cmbRouteOrigin.Text;
            string d = cmbRouteDest.Text;
            if (!int.TryParse(txtDist.Text, out int dist)) return;

            DbHelper.AddRoute(o, d, dist);
            FlightService.Network.AddRoute(o, d, dist);
            MessageBox.Show("Route Connected!");
        }

        private void BtnSchedule_Click(object? sender, EventArgs e)
        {
            string o = cmbFOrigin.Text.Trim();
            string d = cmbFDest.Text.Trim();

            if (string.IsNullOrEmpty(o) || string.IsNullOrEmpty(d))
            {
                MessageBox.Show("Please select Origin and Destination.");
                return;
            }

            if (o.Equals(d, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Origin and Destination cannot be the same!");
                return;
            }

            if (!FlightService.Network.IsConnected(o, d))
            {
                MessageBox.Show($"Error: No direct route exists from {o} to {d}!\nPlease go to 'Map Routes' tab and connect them validation first.");
                return;
            }
            // Create Flight
            Flight f = new Flight
            {
                OriginCode = o,
                DestinationCode = d,
                FlightDate = dtpFlight.Value,
                DurationMinutes = int.Parse(txtDuration.Text),
                Price = decimal.Parse(txtPrice.Text),
                TotalSeats = (int)numTotalSeats.Value,  
                SeatsAvailable = (int)numTotalSeats.Value
            };

            DbHelper.ScheduleFlight(f);
            FlightService.FlightSchedule.Insert(f);
            MessageBox.Show("Flight Scheduled Successfully!");
        }

        private void CmbFOrigin_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFOrigin.Text)) return;

            var neighbors = FlightService.Network.GetNeighbors(cmbFOrigin.Text);

            cmbFDest.Items.Clear();
            Node<string>? n = neighbors.Head;
            while (n != null)
            {
                cmbFDest.Items.Add(n.Data);
                n = n.Next;
            }

            // Reset selection
            cmbFDest.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void tabAirport_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            this.Hide();
            m.Show();
        }

        private void BtnApproveBookings_Click(object? sender, EventArgs e)
        {
            frmAdminBookingApprovals approvalForm = new frmAdminBookingApprovals();
            approvalForm.Show();
        }

        private void BtnManifest_Click(object? sender, EventArgs e)
        {
            frmPassengerManifest manifestForm = new frmPassengerManifest();
            manifestForm.Show();
        }

        private void BtnManageAirports_Click(object? sender, EventArgs e)
        {
            frmManageAirports manageAirportsForm = new frmManageAirports();
            manageAirportsForm.Show();
        }

        private void BtnDeleteAirport_Click(object? sender, EventArgs e)
        {
            frmManageAirports manageAirportsForm = new frmManageAirports();
            manageAirportsForm.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void txtDist_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFlight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void countrytxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtACity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
