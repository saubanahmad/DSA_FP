using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom button control with automatic theme styling
    /// </summary>
    public class CustomButton : Button
    {
        private ButtonType _buttonType = ButtonType.Primary;
        private const int BorderRadius = 3;

        public CustomButton()
        {
            ApplyStyle();
            this.Resize += (s, e) => SetRoundedRegion();
        }

        /// <summary>
        /// Gets or sets the button type/style
        /// </summary>
        public ButtonType ButtonType
        {
            get => _buttonType;
            set
            {
                _buttonType = value;
                ApplyStyle();
            }
        }

        private void ApplyStyle()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Cursor = Cursors.Hand;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.Height = Math.Max(this.Height, 40);

            switch (_buttonType)
            {
                case ButtonType.Primary:
                    this.BackColor = Color.FromArgb(106, 117, 155); 
                    this.ForeColor = Color.White;
                    //this.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
                    this.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235); // Darker blue
                    break;

                case ButtonType.Success:
                    this.BackColor = Color.FromArgb(34, 197, 94); // Green 500
                    this.ForeColor = Color.White;
                    //this.FlatAppearance.BorderColor = Color.FromArgb(34, 197, 94);
                    this.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
                    break;

                case ButtonType.Warning:
                    this.BackColor = Color.FromArgb(251, 146, 60); // Orange 400
                    this.ForeColor = Color.White;
                    //this.FlatAppearance.BorderColor = Color.FromArgb(251, 146, 60);
                    this.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 88, 12);
                    break;

                case ButtonType.Danger:
                    this.BackColor = Color.FromArgb(239, 68, 68); // Red 500
                    this.ForeColor = Color.White;
                    //this.FlatAppearance.BorderColor = Color.FromArgb(239, 68, 68);
                    this.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
                    break;

                case ButtonType.Outline:
                    this.BackColor = Color.Transparent;
                    this.ForeColor = Color.FromArgb(59, 130, 246);
                    this.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
                    this.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 58, 138);
                    break;

                case ButtonType.Ghost:
                    this.BackColor = Color.FromArgb(185, 212, 241); // Slate 800
                    this.ForeColor = Color.FromArgb(33, 39, 61); // Slate 50
                    //this.FlatAppearance.BorderColor = Color.FromArgb(71, 85, 105); // Slate 600
                    this.FlatAppearance.MouseOverBackColor = Color.White; // Slate 700
                    break;
            }
        }
        private void SetRoundedRegion()
        {
            using (GraphicsPath path = GetRoundedRectanglePath(this.ClientRectangle, BorderRadius))
            {
                this.Region = new Region(path);
            }
        }

        private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // Top left arc
            path.AddArc(arcRect, 180, 90);

            // Top right arc
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // Bottom right arc
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // Bottom left arc
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }
    }

    /// <summary>
    /// Button style types
    /// </summary>
    public enum ButtonType
    {
        Primary,
        Success,
        Warning,
        Danger,
        Outline,
        Ghost
    }
}
