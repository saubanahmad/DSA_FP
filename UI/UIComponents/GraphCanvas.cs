using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom panel optimized for graph visualization with double buffering
    /// </summary>
    public class GraphCanvas : Panel
    {
        public GraphCanvas()
        {
            ApplyStyle();
            EnableDoubleBuffering();
        }

        private void ApplyStyle()
        {
            this.BackColor = Color.Black;
            this.Dock = DockStyle.Fill;
        }

        private void EnableDoubleBuffering()
        {
            // Enable double buffering for smooth rendering
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }
    }
}
