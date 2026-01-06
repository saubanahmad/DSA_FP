using System;
using System.Windows.Forms;
using FlightBookingSystem.Services;
using FlightBookingSystem.UI;

namespace FlightBookingSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Initialize DSA System (Load DB Data)
                FlightService.InitializeSystem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup Error when connecting to DB: {ex.Message}\nEnsure MySQL is running and Schema is applied.");
            }

            Application.Run(new MainForm());
            //Application.Run(new frmViewTicket());
        }
    }
}
