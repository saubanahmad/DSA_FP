using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlightBookingSystem.UI
{
    public static class Theme
    {
        // Professional Color Palette - Modern Airline Theme
        public static Color PrimaryDark = Color.FromArgb(15, 23, 42);        // Slate 900
        public static Color SecondaryDark = Color.FromArgb(30, 41, 59);      // Slate 800
        public static Color CardBackground = Color.FromArgb(51, 65, 85);     // Slate 700
        public static Color AccentBlue = Color.FromArgb(59, 130, 246);       // Blue 500
        public static Color AccentOrange = Color.FromArgb(251, 146, 60);     // Orange 400
        public static Color AccentGreen = Color.FromArgb(34, 197, 94);       // Green 500
        public static Color TextPrimary = Color.FromArgb(248, 250, 252);     // Slate 50
        public static Color TextSecondary = Color.FromArgb(148, 163, 184);   // Slate 400
        public static Color BorderColor = Color.FromArgb(71, 85, 105);       // Slate 600
        public static Color SuccessColor = Color.FromArgb(16, 185, 129);     // Emerald 500
        public static Color WarningColor = Color.FromArgb(245, 158, 11);     // Amber 500
        public static Color DangerColor = Color.FromArgb(239, 68, 68);       // Red 500

        // Fonts
        public static Font HeaderFont = new Font("Segoe UI", 18F, FontStyle.Bold);
        public static Font SubHeaderFont = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static Font SmallFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static Font ButtonFont = new Font("Segoe UI", 10F, FontStyle.Bold);

        public static void ApplyToForm(Form form)
        {
            form.BackColor = PrimaryDark;
            form.ForeColor = TextPrimary;
            form.Font = BodyFont;
        }

        public static void StyleButton(Button btn, ButtonStyle style = ButtonStyle.Primary)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = ButtonFont;
            btn.Height = Math.Max(btn.Height, 40);
            
            // Add rounded corners effect
            btn.FlatAppearance.BorderSize = 2;
            
            switch (style)
            {
                case ButtonStyle.Primary:
                    btn.BackColor = AccentBlue;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = AccentBlue;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235); // Darker blue
                    break;
                    
                case ButtonStyle.Success:
                    btn.BackColor = AccentGreen;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = AccentGreen;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
                    break;
                    
                case ButtonStyle.Warning:
                    btn.BackColor = AccentOrange;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = AccentOrange;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 88, 12);
                    break;
                    
                case ButtonStyle.Danger:
                    btn.BackColor = DangerColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = DangerColor;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
                    break;
                    
                case ButtonStyle.Outline:
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = AccentBlue;
                    btn.FlatAppearance.BorderColor = AccentBlue;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 58, 138);
                    break;
                    
                case ButtonStyle.Ghost:
                    btn.BackColor = SecondaryDark;
                    btn.ForeColor = TextPrimary;
                    btn.FlatAppearance.BorderColor = BorderColor;
                    btn.FlatAppearance.MouseOverBackColor = CardBackground;
                    break;
            }
        }

        public static void StyleTextBox(TextBox txt)
        {
            txt.BackColor = SecondaryDark;
            txt.ForeColor = TextPrimary;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = BodyFont;
            txt.Height = Math.Max(txt.Height, 35);
        }

        public static void StyleComboBox(ComboBox cmb)
        {
            cmb.BackColor = SecondaryDark;
            cmb.ForeColor = TextPrimary;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = BodyFont;
            cmb.Height = Math.Max(cmb.Height, 35);
        }

        public static void StyleDateTimePicker(DateTimePicker dtp)
        {
            dtp.BackColor = SecondaryDark;
            dtp.ForeColor = TextPrimary;
            dtp.Font = BodyFont;
            dtp.CalendarMonthBackground = SecondaryDark;
            dtp.CalendarForeColor = TextPrimary;
            dtp.CalendarTitleBackColor = CardBackground;
            dtp.CalendarTitleForeColor = TextPrimary;
        }

        public static void StyleListBox(ListBox lst)
        {
            lst.BackColor = SecondaryDark;
            lst.ForeColor = TextPrimary;
            lst.BorderStyle = BorderStyle.FixedSingle;
            lst.Font = BodyFont;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = PrimaryDark;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = BorderColor;
            grid.Font = BodyFont;
            
            // Header styling
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = CardBackground;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            grid.ColumnHeadersHeight = 45;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Cell styling
            grid.DefaultCellStyle.BackColor = SecondaryDark;
            grid.DefaultCellStyle.ForeColor = TextPrimary;
            grid.DefaultCellStyle.SelectionBackColor = AccentBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            grid.RowTemplate.Height = 50;
            
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 55, 72);
            
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

        public static void StyleTabControl(TabControl tabs)
        {
            tabs.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            
            foreach (TabPage tab in tabs.TabPages)
            {
                tab.BackColor = PrimaryDark;
                tab.ForeColor = TextPrimary;
                tab.Padding = new Padding(20);
            }
        }

        public static void StyleLabel(Label lbl, LabelStyle style = LabelStyle.Body)
        {
            switch (style)
            {
                case LabelStyle.Header:
                    lbl.Font = HeaderFont;
                    lbl.ForeColor = TextPrimary;
                    break;
                    
                case LabelStyle.SubHeader:
                    lbl.Font = SubHeaderFont;
                    lbl.ForeColor = TextPrimary;
                    break;
                    
                case LabelStyle.Body:
                    lbl.Font = BodyFont;
                    lbl.ForeColor = TextPrimary;
                    break;
                    
                case LabelStyle.Muted:
                    lbl.Font = SmallFont;
                    lbl.ForeColor = TextSecondary;
                    break;
                    
                case LabelStyle.Accent:
                    lbl.Font = BodyFont;
                    lbl.ForeColor = AccentBlue;
                    break;
            }
        }

        public static void StyleGroupBox(GroupBox grp)
        {
            grp.ForeColor = TextPrimary;
            grp.Font = SubHeaderFont;
        }

        public static void StylePanel(Panel pnl, PanelStyle style = PanelStyle.Default)
        {
            switch (style)
            {
                case PanelStyle.Card:
                    pnl.BackColor = CardBackground;
                    pnl.Padding = new Padding(20);
                    break;
                    
                case PanelStyle.Header:
                    pnl.BackColor = SecondaryDark;
                    pnl.Padding = new Padding(15);
                    break;
                    
                case PanelStyle.Default:
                    pnl.BackColor = PrimaryDark;
                    break;
            }
        }

        // Helper method to create gradient background
        public static void DrawGradientBackground(Graphics g, Rectangle bounds, Color color1, Color color2)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(bounds, color1, color2, 45F))
            {
                g.FillRectangle(brush, bounds);
            }
        }

        // Helper to create card-like panel
        public static Panel CreateCard(int x, int y, int width, int height)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = CardBackground,
                Padding = new Padding(20)
            };
            return card;
        }
    }

    public enum ButtonStyle
    {
        Primary,
        Success,
        Warning,
        Danger,
        Outline,
        Ghost
    }

    public enum LabelStyle
    {
        Header,
        SubHeader,
        Body,
        Muted,
        Accent
    }

    public enum PanelStyle
    {
        Default,
        Card,
        Header
    }
}
