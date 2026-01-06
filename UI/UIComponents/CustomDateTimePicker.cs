using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom date time picker control with automatic dark theme styling
    /// </summary>
    public class CustomDateTimePicker : DateTimePicker
    {
        public CustomDateTimePicker()
        {
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            //this.BackColor = Color.FromArgb(30, 41, 59); // Slate 800
            //this.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            //this.CalendarMonthBackground = Color.FromArgb(30, 41, 59); // Slate 800
            //this.CalendarForeColor = Color.FromArgb(248, 250, 252); // Slate 50
            //this.CalendarTitleBackColor = Color.FromArgb(51, 65, 85); // Slate 700
            //this.CalendarTitleForeColor = Color.FromArgb(248, 250, 252); // Slate 50
        }
    }
}
