using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom label control with automatic theme styling based on label type
    /// </summary>
    public class CustomLabel : Label
    {
        private LabelType _labelType = LabelType.Body;

        public CustomLabel()
        {
            ApplyStyle();
        }

        /// <summary>
        /// Gets or sets the label type/style
        /// </summary>
        public LabelType LabelType
        {
            get => _labelType;
            set
            {
                _labelType = value;
                ApplyStyle();
            }
        }

        private void ApplyStyle()
        {
            switch (_labelType)
            {
                case LabelType.Header:
                    this.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                    this.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
                    break;

                case LabelType.SubHeader:
                    this.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                    this.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
                    break;

                case LabelType.Body:
                    this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    this.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
                    break;

                case LabelType.Muted:
                    this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    this.ForeColor = Color.FromArgb(148, 163, 184); // Slate 400
                    break;

                case LabelType.Accent:
                    this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    this.ForeColor = Color.FromArgb(59, 130, 246); // Blue 500
                    break;
            }
        }
    }

    /// <summary>
    /// Label style types
    /// </summary>
    public enum LabelType
    {
        Header,
        SubHeader,
        Body,
        Muted,
        Accent
    }
}
