using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom list box control with automatic dark theme styling
    /// </summary>
    public class CustomListBox : ListBox
    {
        public CustomListBox()
        {
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            this.BackColor = Color.FromArgb(30, 41, 59); // Slate 800
            this.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        }
    }
}
