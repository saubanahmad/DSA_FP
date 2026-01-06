using System;
using System.Windows.Forms;
using System.IO;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.Data;
using FlightBookingSystem.UI.UIComponents;
using FlightBookingSystem.Core.DataStructures;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FlightBookingSystem.UI
{
    public class frmViewTicket : Form
    {
        private CustomLabel lblPNR;
        private CustomTextBox txtPNR;
        private CustomButton btnSearch;
        private CustomGroupBox grpTicketDetails;
        private CustomLabel lblFlightInfo;
        private CustomLabel lblStatus;
        private CustomButton btnCancelBooking;
        private CustomLabel lblStatusWarning;  // Warning label for Pending/Cancelled status
        private CustomButton customButton1;
        private Booking? currentBooking;

        public frmViewTicket()
        {
            InitializeComponent();
            Theme.ApplyToForm(this);
        }

        private void InitializeComponent()
        {
            lblPNR = new CustomLabel();
            txtPNR = new CustomTextBox();
            btnSearch = new CustomButton();
            grpTicketDetails = new CustomGroupBox();
            customButton1 = new CustomButton();
            lblFlightInfo = new CustomLabel();
            lblStatus = new CustomLabel();
            btnCancelBooking = new CustomButton();
            lblStatusWarning = new CustomLabel();
            grpTicketDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblPNR
            // 
            lblPNR.Anchor = AnchorStyles.Top;
            lblPNR.AutoSize = true;
            lblPNR.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblPNR.ForeColor = Color.FromArgb(248, 250, 252);
            lblPNR.LabelType = LabelType.Body;
            lblPNR.Location = new Point(134, 28);
            lblPNR.Name = "lblPNR";
            lblPNR.Size = new Size(104, 28);
            lblPNR.TabIndex = 0;
            lblPNR.Text = "Enter PNR:";
            // 
            // txtPNR
            // 
            txtPNR.Anchor = AnchorStyles.Top;
            txtPNR.BackColor = Color.FromArgb(30, 41, 59);
            txtPNR.BorderStyle = BorderStyle.FixedSingle;
            txtPNR.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPNR.ForeColor = Color.FromArgb(248, 250, 252);
            txtPNR.Location = new Point(256, 26);
            txtPNR.Name = "txtPNR";
            txtPNR.Size = new Size(200, 34);
            txtPNR.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top;
            btnSearch.BackColor = Color.FromArgb(106, 117, 155);
            btnSearch.ButtonType = ButtonType.Primary;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(476, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // grpTicketDetails
            // 
            grpTicketDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTicketDetails.Controls.Add(customButton1);
            grpTicketDetails.Controls.Add(lblFlightInfo);
            grpTicketDetails.Controls.Add(lblStatus);
            grpTicketDetails.Controls.Add(btnCancelBooking);
            grpTicketDetails.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            grpTicketDetails.ForeColor = Color.FromArgb(248, 250, 252);
            grpTicketDetails.Location = new Point(23, 88);
            grpTicketDetails.Name = "grpTicketDetails";
            grpTicketDetails.Size = new Size(700, 350);
            grpTicketDetails.TabIndex = 3;
            grpTicketDetails.TabStop = false;
            grpTicketDetails.Text = "Ticket Details";
            grpTicketDetails.Visible = false;
            // 
            // customButton1
            // 
            customButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            customButton1.BackColor = Color.FromArgb(34, 197, 94);
            customButton1.ButtonType = ButtonType.Success;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            customButton1.ForeColor = Color.White;
            customButton1.Location = new Point(476, 280);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(200, 45);
            customButton1.TabIndex = 5;
            customButton1.Text = "Print Ticket";
            customButton1.UseVisualStyleBackColor = false;
            customButton1.Click += BtnPrintTicket_Click;
            // 
            // lblFlightInfo
            // 
            lblFlightInfo.AutoSize = true;
            lblFlightInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFlightInfo.ForeColor = Color.FromArgb(248, 250, 252);
            lblFlightInfo.LabelType = LabelType.Body;
            lblFlightInfo.Location = new Point(20, 40);
            lblFlightInfo.Name = "lblFlightInfo";
            lblFlightInfo.Size = new Size(71, 28);
            lblFlightInfo.TabIndex = 0;
            lblFlightInfo.Text = "Flight: ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(248, 250, 252);
            lblStatus.LabelType = LabelType.Body;
            lblStatus.Location = new Point(20, 220);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(74, 28);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status: ";
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.BackColor = Color.FromArgb(239, 68, 68);
            btnCancelBooking.ButtonType = ButtonType.Danger;
            btnCancelBooking.FlatAppearance.BorderSize = 0;
            btnCancelBooking.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
            btnCancelBooking.FlatStyle = FlatStyle.Flat;
            btnCancelBooking.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelBooking.ForeColor = Color.White;
            btnCancelBooking.Location = new Point(20, 280);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(200, 45);
            btnCancelBooking.TabIndex = 4;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = false;
            btnCancelBooking.Click += BtnCancelBooking_Click;
            // 
            // lblStatusWarning
            // 
            lblStatusWarning.Anchor = AnchorStyles.Top;
            lblStatusWarning.AutoSize = true;
            lblStatusWarning.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblStatusWarning.ForeColor = Color.FromArgb(248, 250, 252);
            lblStatusWarning.LabelType = LabelType.Body;
            lblStatusWarning.Location = new Point(100, 150);
            lblStatusWarning.Name = "lblStatusWarning";
            lblStatusWarning.Size = new Size(0, 28);
            lblStatusWarning.TabIndex = 4;
            lblStatusWarning.TextAlign = ContentAlignment.MiddleCenter;
            lblStatusWarning.Visible = false;
            // 
            // frmViewTicket
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 450);
            Controls.Add(lblStatusWarning);
            Controls.Add(grpTicketDetails);
            Controls.Add(btnSearch);
            Controls.Add(txtPNR);
            Controls.Add(lblPNR);
            Name = "frmViewTicket";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Ticket & Cancel Booking";
            Load += frmViewTicket_Load;
            grpTicketDetails.ResumeLayout(false);
            grpTicketDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void frmViewTicket_Load(object sender, EventArgs e)
        {
            txtPNR.Clear();
            grpTicketDetails.Visible = false;
            lblStatusWarning.Visible = false;
            currentBooking = null;
        }
        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            string pnr = txtPNR.Text.Trim();
            if (string.IsNullOrEmpty(pnr))
            {
                MessageBox.Show("Please enter a PNR", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            currentBooking = FlightService.GetBookingByPNR(pnr, out string error);

            if (currentBooking == null || currentBooking.FlightDetails == null)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grpTicketDetails.Visible = false;
                lblStatusWarning.Visible = false;
                return;
            }


            string status = currentBooking.Status;

            if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase) ||
                status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                grpTicketDetails.Visible = false;
                lblStatusWarning.Text = $"Ticket is not generated. Current Status: {status}";
                lblStatusWarning.Visible = true;
                return;
            }

            lblStatusWarning.Visible = false;

            Flight flight = currentBooking.FlightDetails;
            lblFlightInfo.Text = $"Flight: {flight.OriginCode} → {flight.DestinationCode}\n" +
                                $"Date: {flight.FlightDate:yyyy-MM-dd HH:mm}\n" +
                                $"Duration: {flight.DurationMinutes} minutes\n" +
                                $"Price: ${flight.Price}";


            lblStatus.Text = $"Status: {currentBooking.Status}";

            grpTicketDetails.Visible = true;
            btnCancelBooking.Enabled = currentBooking.Status != "Cancelled";
        }

        private void BtnCancelBooking_Click(object? sender, EventArgs e)
        {
            if (currentBooking == null || currentBooking.FlightDetails == null)
            {
                MessageBox.Show("No booking selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to cancel this booking?\\n\\nPNR: {currentBooking.PNR}\\nFlight: {currentBooking.FlightDetails.OriginCode} → {currentBooking.FlightDetails.DestinationCode}",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes) return;

            // Attempt to cancel with 24-hour validation
            bool success = DbHelper.CancelBooking(currentBooking.PNR, out string errorMessage);

            if (success)
            {
                MessageBox.Show("Booking cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grpTicketDetails.Visible = false;
                txtPNR.Clear();
                currentBooking = null;
            }
            else
            {
                MessageBox.Show(errorMessage, "Cancellation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrintTicket_Click(object? sender, EventArgs e)
        {
            if (currentBooking == null || currentBooking.FlightDetails == null)
            {
                MessageBox.Show("No ticket loaded. Please search for a booking first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!currentBooking.Status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Cannot print ticket. Booking status is: {currentBooking.Status}\n\nOnly confirmed bookings can be printed.", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveDialog.FileName = $"Ticket_{currentBooking.PNR}.pdf";
                    saveDialog.Title = "Save Ticket as PDF";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        GenerateTicketPDF(saveDialog.FileName);

                        var result = MessageBox.Show($"Ticket saved successfully!\n\nLocation: {saveDialog.FileName}\n\nWould you like to open the PDF?",
                            "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateTicketPDF(string filePath)
        {
            if (currentBooking == null || currentBooking.FlightDetails == null)
                return;

            // Create PDF document
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, iTextSharp.text.BaseColor.Black);
                iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, new iTextSharp.text.BaseColor(34, 197, 94));
                iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.BaseColor.Black);
                iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, iTextSharp.text.BaseColor.Black);

                Paragraph title = new Paragraph("FLIGHT TICKET", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20;
                document.Add(title);

                Paragraph status = new Paragraph($"Status: {currentBooking.Status.ToUpper()}", headerFont);
                status.Alignment = Element.ALIGN_CENTER;
                status.SpacingAfter = 30;
                document.Add(status);

                Paragraph pnr = new Paragraph();
                pnr.Add(new Chunk("PNR: ", boldFont));
                pnr.Add(new Chunk(currentBooking.PNR, normalFont));
                pnr.SpacingAfter = 10;
                document.Add(pnr);

                Paragraph bookingDate = new Paragraph();
                bookingDate.Add(new Chunk("Booking Date: ", boldFont));
                bookingDate.Add(new Chunk(currentBooking.BookingDate.ToString("yyyy-MM-dd"), normalFont));
                bookingDate.SpacingAfter = 20;
                document.Add(bookingDate);

                document.Add(new Paragraph("_____________________________________________________________________"));
                document.Add(new Paragraph(" "));

                Paragraph flightHeader = new Paragraph("Flight Information", headerFont);
                flightHeader.SpacingAfter = 15;
                document.Add(flightHeader);

                Flight flight = currentBooking.FlightDetails;

                Paragraph route = new Paragraph();
                route.Add(new Chunk("Route: ", boldFont));
                route.Add(new Chunk($"{flight.OriginCode} → {flight.DestinationCode}", normalFont));
                route.SpacingAfter = 10;
                document.Add(route);

                Paragraph flightDate = new Paragraph();
                flightDate.Add(new Chunk("Flight Date: ", boldFont));
                flightDate.Add(new Chunk(flight.FlightDate.ToString("dd MMM yyyy HH:mm"), normalFont));
                flightDate.SpacingAfter = 10;
                document.Add(flightDate);

                Paragraph duration = new Paragraph();
                duration.Add(new Chunk("Duration: ", boldFont));
                duration.Add(new Chunk($"{flight.DurationMinutes} minutes", normalFont));
                duration.SpacingAfter = 10;
                document.Add(duration);

                Paragraph price = new Paragraph();
                price.Add(new Chunk("Price: ", boldFont));
                price.Add(new Chunk($"${flight.Price}", normalFont));
                price.SpacingAfter = 20;
                document.Add(price);

                document.Add(new Paragraph("_____________________________________________________________________"));
                document.Add(new Paragraph(" "));

                Paragraph passengerHeader = new Paragraph("Passenger Manifest", headerFont);
                passengerHeader.SpacingAfter = 15;
                document.Add(passengerHeader);

                Node<Passenger>? n = currentBooking.PassengerList.Head;
                int passengerNum = 1;
                while (n != null)
                {
                    Paragraph passenger = new Paragraph();
                    passenger.Add(new Chunk($"{passengerNum}. ", boldFont));
                    passenger.Add(new Chunk($"{n.Data.FullName} (Passport: {n.Data.PassportNumber})", normalFont));
                    passenger.SpacingAfter = 8;
                    document.Add(passenger);

                    n = n.Next;
                    passengerNum++;
                }

                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("_____________________________________________________________________"));
                Paragraph footer = new Paragraph("Thank you for choosing our airline!", normalFont);
                footer.Alignment = Element.ALIGN_CENTER;
                footer.SpacingBefore = 20;
                document.Add(footer);

                document.Close();
            }
        }

        private void lblPassengers_Click(object sender, EventArgs e)
        {

        }
    }
}
