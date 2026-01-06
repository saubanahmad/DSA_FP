using System.Drawing;
using System.Windows.Forms;

namespace FlightBookingSystem.UI.UIComponents
{
    /// <summary>
    /// Custom data grid view with professional dark theme styling
    /// </summary>
    public class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            // Grid styling
            this.BackgroundColor = Color.FromArgb(15, 23, 42); // Slate 900
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridColor = Color.FromArgb(71, 85, 105); // Slate 600
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Header styling
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85); // Slate 700
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
            this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            this.ColumnHeadersHeight = 45;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Cell styling
            this.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59); // Slate 800
            this.DefaultCellStyle.ForeColor = Color.FromArgb(248, 250, 252); // Slate 50
            this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246); // Blue 500
            this.DefaultCellStyle.SelectionForeColor = Color.White;
            this.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            this.RowTemplate.Height = 50;

            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 55, 72);

            // Behavior
            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ReadOnly = true;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
        }
    }
}
