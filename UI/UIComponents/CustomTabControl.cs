using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom tab control with automatic dark theme styling for all tab pages
    /// </summary>
    public class CustomTabControl : TabControl
    {
        public CustomTabControl()
        {
            ApplyStyle();
            this.ControlAdded += CustomTabControl_ControlAdded;
        }

        private void ApplyStyle()
        {
            this.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            
            // Style existing tab pages
            foreach (TabPage tab in this.TabPages)
            {
                StyleTabPage(tab);
            }
        }

        private void CustomTabControl_ControlAdded(object? sender, ControlEventArgs e)
        {
            // Auto-style newly added tab pages
            if (e.Control is TabPage tabPage)
            {
                StyleTabPage(tabPage);
            }
        }

        private void StyleTabPage(TabPage tab)
        {
            tab.BackColor = Color.FromArgb(15, 23, 42); // Slate 900
            tab.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
            tab.Padding = new Padding(20);
        }
    }
}
