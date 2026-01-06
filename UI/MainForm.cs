using System;
using System.Drawing;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.Data;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.UI
{
    public partial class MainForm : Form
    {
        private Flight? selectedFlight;
        private MyLinkedList<Passenger> currentPassengers;
        private PassengerStack passengerStack; // for Undo 

        public MainForm()
        {
            InitializeComponent();

            currentPassengers = new MyLinkedList<Passenger>();
            passengerStack = new PassengerStack(); // Initialize stack

            // Setup Grid manually
            gridResults.Columns.Add("Id", "ID");
            gridResults.Columns.Add("Origin", "Origin");
            gridResults.Columns.Add("Dest", "Dest");
            gridResults.Columns.Add("Date", "Date");
            gridResults.Columns.Add("Price", "Price");

            // Add custom buttons
            AddCustomButtons();
        }

        private void AddCustomButtons()
        {


        }


        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            LoginForm a = new LoginForm();
            this.Hide();  
            a.ShowDialog();  
            this.Show();    
        }


        private void TxtSearchOrigin_TextChanged(object sender, EventArgs e) => UpdateSuggestions(txtSearchOrigin.Text, lstSuggestionsO);
        private void TxtSearchDest_TextChanged(object sender, EventArgs e) => UpdateSuggestions(txtSearchDest.Text, lstSuggestionsD);

        private void LstSuggestionsO_Click(object sender, EventArgs e)
        {
            if (lstSuggestionsO.Text != "") txtSearchOrigin.Text = lstSuggestionsO.Text.Split('-')[0].Trim();
            lstSuggestionsO.Visible = false;
        }

        private void LstSuggestionsD_Click(object sender, EventArgs e)
        {
            if (lstSuggestionsD.Text != "") txtSearchDest.Text = lstSuggestionsD.Text.Split('-')[0].Trim();
            lstSuggestionsD.Visible = false;
        }

        private void UpdateSuggestions(string prefix, ListBox lst)
        {
            lst.Items.Clear();
            if (string.IsNullOrEmpty(prefix)) { lst.Visible = false; return; }

            var results = FlightService.AirportLookup.AutoComplete(prefix);
            Node<string>? n = results.Head;
            if (n == null) { lst.Visible = false; return; }

            while (n != null)
            {
                lst.Items.Add(n.Data);
                n = n.Next;
            }
            lst.Visible = true;
            lst.BringToFront();
        }

        private void BtnSearchDate_Click(object sender, EventArgs e)
        {
            gridResults.Rows.Clear();
            var results = FlightService.FlightSchedule.SearchByDate(dtpSearch.Value);
            Node<Flight>? n = results.Head;
            while (n != null)
            {
                bool matchO = string.IsNullOrEmpty(txtSearchOrigin.Text) || n.Data.OriginCode == txtSearchOrigin.Text;
                bool matchD = string.IsNullOrEmpty(txtSearchDest.Text) || n.Data.DestinationCode == txtSearchDest.Text;

                if (matchO && matchD)
                {
                    gridResults.Rows.Add(n.Data.FlightID, n.Data.OriginCode, n.Data.DestinationCode, n.Data.FlightDate, n.Data.Price);
                }
                n = n.Next;
            }
        }

        private void BtnSortPrice_Click(object sender, EventArgs e)
        {
            MyMinHeap heap = new MyMinHeap();

            void AddToHeapRec(FlightNode? r)
            {
                if (r == null) return;
                AddToHeapRec(r.Left);

                bool matchO = string.IsNullOrEmpty(txtSearchOrigin.Text) || r.Data.OriginCode == txtSearchOrigin.Text;
                bool matchD = string.IsNullOrEmpty(txtSearchDest.Text) || r.Data.DestinationCode == txtSearchDest.Text;

                if (matchO && matchD)
                {
                    heap.Insert(r.Data);
                }
                AddToHeapRec(r.Right);
            }

            AddToHeapRec(FlightService.FlightSchedule.Root);

            gridResults.Rows.Clear();
            while (!heap.IsEmpty)
            {
                Flight f = heap.ExtractMin();
                gridResults.Rows.Add(f.FlightID, f.OriginCode, f.DestinationCode, f.FlightDate, f.Price);
            }
        }

        private void BtnGoToBook_Click(object sender, EventArgs e)
        {
            if (gridResults.SelectedRows.Count == 0) return;
            int fid = Convert.ToInt32(gridResults.SelectedRows[0].Cells[0].Value);

            selectedFlight = FindFlightInBST(FlightService.FlightSchedule.Root, fid);

            if (selectedFlight != null)
            {
                lblSelectedFlight.Text = selectedFlight.ToString();
                tabs.SelectedIndex = 1;
            }
        }

        private Flight? FindFlightInBST(FlightNode? r, int id)
        {
            if (r == null) return null;
            if (r.Data.FlightID == id) return r.Data;
            var left = FindFlightInBST(r.Left, id);
            if (left != null) return left;
            return FindFlightInBST(r.Right, id);
        }

        private void BtnAddPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassName.Text) || string.IsNullOrWhiteSpace(txtPassPassport.Text)) return;

            int age = 0;
            int.TryParse(txtPassAge.Text, out age);

            var parts = txtPassName.Text.Trim().Split(' ');
            string fName = parts[0];
            string lName = parts.Length > 1 ? string.Join(" ", parts.Skip(1)) : ".";
            string email = textEmail.Text;

            Passenger p = new Passenger
            {
                FirstName = fName,
                LastName = lName,
                Age = age,
                PassportNumber = txtPassPassport.Text,
                Email = email
            };

            passengerStack.Push(p);

            currentPassengers.AddLast(p);
            lstPassengers.Items.Add($"{p.FullName} ({p.PassportNumber})");
            txtPassName.Clear(); txtPassPassport.Clear(); txtPassAge.Clear();
        }
        private void BtnUndo_Click(object? sender, EventArgs e)
        {
            if (passengerStack.IsEmpty)
            {
                MessageBox.Show("No passengers to undo!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Passenger removed = passengerStack.Pop();

            Node<Passenger>? current = currentPassengers.Head;
            Node<Passenger>? prev = null;
            Node<Passenger>? lastMatch = null;
            Node<Passenger>? lastMatchPrev = null;

            while (current != null)
            {
                if (current.Data.PassportNumber == removed.PassportNumber)
                {
                    lastMatch = current;
                    lastMatchPrev = prev;
                }
                prev = current;
                current = current.Next;
            }

            if (lastMatch != null)
            {
                if (lastMatchPrev == null)
                {
                    currentPassengers.Head = lastMatch.Next;
                }
                else
                {
                    lastMatchPrev.Next = lastMatch.Next;
                }
            }

            if (lstPassengers.Items.Count > 0)
            {
                lstPassengers.Items.RemoveAt(lstPassengers.Items.Count - 1);
            }

            MessageBox.Show($"Removed: {removed.FullName}", "Undo Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnViewTicket_Click(object? sender, EventArgs e)
        {
            frmViewTicket viewTicketForm = new frmViewTicket();
            viewTicketForm.Show();
        }

        private void BtnConfirmBook_Click(object sender, EventArgs e)
        {
            if (selectedFlight == null)
            {
                MessageBox.Show("Please select a flight first!", "No Flight Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentPassengers.Count == 0)
            {
                MessageBox.Show("Please add at least one passenger before booking!", "No Passengers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pnr = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

            Booking b = new Booking
            {
                PNR = pnr,
                FlightID = selectedFlight.FlightID,
                BookingDate = DateTime.Now,
                Status = "Pending", 
                FlightDetails = selectedFlight,
                PassengerList = currentPassengers
            };

            try
            {
                DbHelper.SaveBooking(b);
                FlightService.Bookings.Insert(pnr, b);

                MessageBox.Show($"Booking Submitted for Approval!\nPNR: {pnr}\nStatus: Pending\n\nAn admin will review your booking shortly.", "Booking Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                currentPassengers = new MyLinkedList<Passenger>();
                passengerStack.Clear(); // Clear stack after booking
                lstPassengers.Items.Clear();
                lblSelectedFlight.Text = "No Flight Selected";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Booking failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGetTicket_Click(object sender, EventArgs e)
        {
            string pnr = txtCheckPNR.Text.Trim();

            if (string.IsNullOrEmpty(pnr))
            {
                MessageBox.Show("Please enter a PNR.");
                return;
            }

            string errorMsg;
            Booking? b = FlightService.GetBookingByPNR(pnr, out errorMsg);

            if (b == null)
            {
                MessageBox.Show($"PNR Not Found: {errorMsg}", "Search Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (b.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "This booking is currently PENDING approval from an Admin.\n\nPlease check back later or contact support.",
                    "Approval Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                webTicket.DocumentText = "<html><body><h2 style='color:orange; font-family:Arial;'>Status: Pending Approval</h2></body></html>";
                return;
            }

            if (b.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This booking has been CANCELLED.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string html = "<html><body style='font-family:Arial; background-color: #f8fafc;'>";
            html += "<div style='border: 2px solid #22c55e; padding: 20px; border-radius: 10px; background-color: white;'>"; // Green border for confirmed
            html += "<h1 style='color: #15803d;'>FLIGHT TICKET</h1>";

            html += $"<h3 style='color: green;'>Status: {b.Status.ToUpper()}</h3>";
            html += $"<p><strong>PNR:</strong> {b.PNR}</p>";

            if (b.FlightDetails != null)
            {
                html += $"<p><strong>Flight:</strong> {b.FlightDetails.OriginCode} &#8594; {b.FlightDetails.DestinationCode}</p>";
                html += $"<p><strong>Date:</strong> {b.FlightDetails.FlightDate:dd MMM yyyy HH:mm}</p>";
            }

            html += "<hr style='border-color: #e2e8f0;'/>";
            html += "<h4>Passenger Manifest</h4><ul>";

            Node<Passenger>? n = b.PassengerList.Head;
            while (n != null)
            {
                html += $"<li>{n.Data.FullName} (Passport: {n.Data.PassportNumber})</li>";
                n = n.Next;
            }
            html += "</ul></div></body></html>";

            webTicket.DocumentText = html;
        }

        private void lblO_Click(object sender, EventArgs e)
        {

        }

        private void lblD_Click(object sender, EventArgs e)
        {

        }

        private void lstPassengers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpPass_Enter(object sender, EventArgs e)
        {

        }

        private void lblT_Click(object sender, EventArgs e)
        {

        }

        private void tabSearch_Click(object sender, EventArgs e)
        {

        }

        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {

        }

        private void undolastBTN_Click(object sender, EventArgs e)
        {
            if (passengerStack.IsEmpty)
            {
                MessageBox.Show("No passengers to undo!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Passenger removed = passengerStack.Pop();

            Node<Passenger>? current = currentPassengers.Head;
            Node<Passenger>? prev = null;
            Node<Passenger>? lastMatch = null;
            Node<Passenger>? lastMatchPrev = null;

            while (current != null)
            {
                if (current.Data.PassportNumber == removed.PassportNumber)
                {
                    lastMatch = current;
                    lastMatchPrev = prev;
                }
                prev = current;
                current = current.Next;
            }

            if (lastMatch != null)
            {
                if (lastMatchPrev == null)
                {
                    currentPassengers.Head = lastMatch.Next;
                }
                else
                {
                    lastMatchPrev.Next = lastMatch.Next;
                }
            }

            if (lstPassengers.Items.Count > 0)
            {
                lstPassengers.Items.RemoveAt(lstPassengers.Items.Count - 1);
            }

            MessageBox.Show($"Removed: {removed.FullName}", "Undo Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void webTicket_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            frmViewTicket viewTicketForm = new frmViewTicket();
            viewTicketForm.Show();
        }

        private void gridResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customButton2_Click(object sender, EventArgs e)
        {

        }

        private void customButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnviewmap_Click(object sender, EventArgs e)
        {
            frmAirportGraph map = new frmAirportGraph();
            map.Show();
        }

        private void customLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
