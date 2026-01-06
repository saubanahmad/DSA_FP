using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom group box control with automatic dark theme styling
    /// </summary>
    public class CustomGroupBox : GroupBox
    {
        public CustomGroupBox()
        {
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            this.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
            this.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        }
    }
}
