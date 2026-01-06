using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom panel control with automatic theme styling based on panel type
    /// </summary>
    public class CustomPanel : Panel
    {
        private PanelType _panelType = PanelType.Default;

        public CustomPanel()
        {
            ApplyStyle();
        }

        /// <summary>
        /// Gets or sets the panel type/style
        /// </summary>
        public PanelType PanelType
        {
            get => _panelType;
            set
            {
                _panelType = value;
                ApplyStyle();
            }
        }

        private void ApplyStyle()
        {
            switch (_panelType)
            {
                case PanelType.Card:
                    this.BackColor = Color.FromArgb(51, 65, 85); // Slate 700
                    this.Padding = new Padding(20);
                    break;

                case PanelType.Header:
                    this.BackColor = Color.FromArgb(30, 41, 59); // Slate 800
                    this.Padding = new Padding(15);
                    break;

                case PanelType.Default:
                    this.BackColor = Color.FromArgb(15, 23, 42); // Slate 900
                    break;
            }
        }
    }

    /// <summary>
    /// Panel style types
    /// </summary>
    public enum PanelType
    {
        Default,
        Card,
        Header
    }
}
