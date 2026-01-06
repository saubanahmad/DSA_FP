using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.UI.UIComponents;
using FlightBookingSystem.Core.DataStructures;

namespace FlightBookingSystem.UI
{
    public class frmAirportGraph : Form
    {
        private CustomPanel pnlControls;
        private CustomComboBox cmbOrigin;
        private CustomComboBox cmbDest;
        private CustomLabel lblOrigin;
        private CustomLabel lblDest;
        private CustomButton btnFindPaths;
        private CustomButton btnRefresh;
        private CustomLabel lblPathCount;
        private GraphCanvas pnlCanvas;

        private GraphService graphService;

        private PathResult[] foundPaths;

        private Color[] neonColors = new Color[]
        {
            Color.FromArgb(57, 255, 20),    // Neon Green -> for shortest path
            Color.FromArgb(0, 255, 255),    // Cyan
            Color.FromArgb(255, 0, 255),    // Magenta
            Color.FromArgb(255, 255, 0),    // Yellow
            Color.FromArgb(255, 105, 180),  // Hot Pink
            Color.FromArgb(0, 191, 255),    // Deep Sky Blue
            Color.FromArgb(255, 69, 0),     // Orange Red
            Color.FromArgb(173, 255, 47)    // Green Yellow
        };

        public frmAirportGraph()
        {
            InitializeComponent();
            InitializeGraphData();
        }

        private void InitializeComponent()
        {
            pnlControls = new CustomPanel();
            lblOrigin = new CustomLabel();
            cmbOrigin = new CustomComboBox();
            lblDest = new CustomLabel();
            cmbDest = new CustomComboBox();
            btnFindPaths = new CustomButton();
            btnRefresh = new CustomButton();
            lblPathCount = new CustomLabel();
            pnlCanvas = new GraphCanvas();
            pnlControls.SuspendLayout();
            SuspendLayout();
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.FromArgb(30, 41, 59);
            pnlControls.Controls.Add(lblOrigin);
            pnlControls.Controls.Add(cmbOrigin);
            pnlControls.Controls.Add(lblDest);
            pnlControls.Controls.Add(cmbDest);
            pnlControls.Controls.Add(btnFindPaths);
            pnlControls.Controls.Add(btnRefresh);
            pnlControls.Controls.Add(lblPathCount);
            pnlControls.Dock = DockStyle.Top;
            pnlControls.Location = new Point(0, 0);
            pnlControls.Name = "pnlControls";
            pnlControls.Padding = new Padding(15);
            pnlControls.PanelType = PanelType.Header;
            pnlControls.Size = new Size(1200, 80);
            pnlControls.TabIndex = 1;
            // 
            // lblOrigin
            // 
            lblOrigin.AutoSize = true;
            lblOrigin.Font = new Font("Segoe UI", 10F);
            lblOrigin.ForeColor = Color.FromArgb(248, 250, 252);
            lblOrigin.LabelType = LabelType.Body;
            lblOrigin.Location = new Point(12, 28);
            lblOrigin.Name = "lblOrigin";
            lblOrigin.Size = new Size(71, 28);
            lblOrigin.TabIndex = 0;
            lblOrigin.Text = "Origin:";
            // 
            // cmbOrigin
            // 
            cmbOrigin.BackColor = Color.FromArgb(30, 41, 59);
            cmbOrigin.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigin.FlatStyle = FlatStyle.Flat;
            cmbOrigin.Font = new Font("Segoe UI", 10F);
            cmbOrigin.ForeColor = Color.FromArgb(248, 250, 252);
            cmbOrigin.Location = new Point(92, 25);
            cmbOrigin.Name = "cmbOrigin";
            cmbOrigin.Size = new Size(209, 36);
            cmbOrigin.TabIndex = 1;
            // 
            // lblDest
            // 
            lblDest.AutoSize = true;
            lblDest.Font = new Font("Segoe UI", 10F);
            lblDest.ForeColor = Color.FromArgb(248, 250, 252);
            lblDest.LabelType = LabelType.Body;
            lblDest.Location = new Point(307, 28);
            lblDest.Name = "lblDest";
            lblDest.Size = new Size(116, 28);
            lblDest.TabIndex = 2;
            lblDest.Text = "Destination:";
            lblDest.Click += lblDest_Click;
            // 
            // cmbDest
            // 
            cmbDest.BackColor = Color.FromArgb(30, 41, 59);
            cmbDest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDest.FlatStyle = FlatStyle.Flat;
            cmbDest.Font = new Font("Segoe UI", 10F);
            cmbDest.ForeColor = Color.FromArgb(248, 250, 252);
            cmbDest.Location = new Point(429, 25);
            cmbDest.Name = "cmbDest";
            cmbDest.Size = new Size(250, 36);
            cmbDest.TabIndex = 3;
            cmbDest.SelectedIndexChanged += cmbDest_SelectedIndexChanged;
            // 
            // btnFindPaths
            // 
            btnFindPaths.BackColor = Color.FromArgb(106, 117, 155);
            btnFindPaths.ButtonType = ButtonType.Primary;
            btnFindPaths.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnFindPaths.FlatAppearance.BorderSize = 0;
            btnFindPaths.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnFindPaths.FlatStyle = FlatStyle.Flat;
            btnFindPaths.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFindPaths.ForeColor = Color.White;
            btnFindPaths.Location = new Point(697, 22);
            btnFindPaths.Name = "btnFindPaths";
            btnFindPaths.Size = new Size(168, 40);
            btnFindPaths.TabIndex = 4;
            btnFindPaths.Text = "Find Paths";
            btnFindPaths.UseVisualStyleBackColor = false;
            btnFindPaths.Click += BtnFindPaths_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(106, 117, 155);
            btnRefresh.ButtonType = ButtonType.Primary;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(59, 130, 246);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(883, 22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 40);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // lblPathCount
            // 
            lblPathCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPathCount.AutoSize = true;
            lblPathCount.Font = new Font("Segoe UI", 10F);
            lblPathCount.ForeColor = Color.FromArgb(248, 250, 252);
            lblPathCount.LabelType = LabelType.Body;
            lblPathCount.Location = new Point(1040, 28);
            lblPathCount.Name = "lblPathCount";
            lblPathCount.Size = new Size(139, 28);
            lblPathCount.TabIndex = 6;
            lblPathCount.Text = "Paths Found: 0";
            lblPathCount.Click += lblPathCount_Click;
            // 
            // pnlCanvas
            // 
            pnlCanvas.BackColor = Color.Black;
            pnlCanvas.Dock = DockStyle.Fill;
            pnlCanvas.Location = new Point(0, 80);
            pnlCanvas.Name = "pnlCanvas";
            pnlCanvas.Size = new Size(1200, 720);
            pnlCanvas.TabIndex = 0;
            pnlCanvas.Paint += PnlCanvas_Paint;
            // 
            // frmAirportGraph
            // 
            BackColor = Color.Black;
            ClientSize = new Size(1200, 800);
            Controls.Add(pnlCanvas);
            Controls.Add(pnlControls);
            Name = "frmAirportGraph";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Path Finder - Airport Network Visualization (Dijkstra's Algorithm)";
            WindowState = FormWindowState.Maximized;
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ResumeLayout(false);
        }

        private void InitializeGraphData()
        {
            try
            {
                graphService = new GraphService();
                graphService.LoadFromDatabase();

                LoadDropdowns();

                foundPaths = new PathResult[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading graph data: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDropdowns()
        {
            cmbOrigin.Items.Clear();
            cmbDest.Items.Clear();

            var airports = graphService.GetAllAirportCodes();

            foreach (var code in airports)
            {
                var data = graphService.GetAirportData(code);
                string display = $"{code} - {data.City}";
                cmbOrigin.Items.Add(display);
                cmbDest.Items.Add(display);
            }

            if (cmbOrigin.Items.Count > 0)
            {
                cmbOrigin.SelectedIndex = 0;
                if (cmbDest.Items.Count > 1)
                    cmbDest.SelectedIndex = 1; 
                else if (cmbDest.Items.Count > 0)
                    cmbDest.SelectedIndex = 0;
            }
        }

        private void BtnFindPaths_Click(object? sender, EventArgs e)
        {
            if (cmbOrigin.SelectedIndex < 0 || cmbDest.SelectedIndex < 0)
            {
                MessageBox.Show("Please select both origin and destination", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RecalculatePaths();
        }
        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            InitializeGraphData();
            foundPaths = new PathResult[0];
            lblPathCount.Text = "Paths Found: 0";
            pnlCanvas.Invalidate();
        }
        private void RecalculatePaths()
        {
            try
            {
                string originCode = cmbOrigin.Text.Split('-')[0].Trim();
                string destCode = cmbDest.Text.Split('-')[0].Trim();

                foundPaths = graphService.FindAllPaths(originCode, destCode, maxDepth: 5);

                // Find shortest path info
                PathResult? shortestPath = null;
                foreach (var path in foundPaths)
                {
                    if (path.IsShortestPath)
                    {
                        shortestPath = path;
                        break;
                    }
                }

                if (shortestPath != null)
                {
                    lblPathCount.Text = $"Paths: {foundPaths.Length} | Shortest: {shortestPath.TotalDistance} km, {shortestPath.StopCount} stops";
                    lblPathCount.ForeColor = Color.FromArgb(57, 255, 20); // Green
                }
                else
                {
                    lblPathCount.Text = $"Paths Found: {foundPaths.Length}";
                    lblPathCount.ForeColor = foundPaths.Length > 0 ? Color.FromArgb(57, 255, 20) : Color.FromArgb(255, 69, 0);
                }

                graphService.CalculateTopologicalLayout(originCode, destCode, pnlCanvas.Width, pnlCanvas.Height);

                // Force redraw
                pnlCanvas.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding paths: {ex.Message}", "Path Finding Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PnlCanvas_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Black);

            if (graphService == null) return;

            var allAirports = graphService.GetAllAirportData();
            if (allAirports.Count == 0) return;
            DrawBaseRoutes(g, allAirports);
            DrawFoundPaths(g);
            DrawAirportNodes(g, allAirports);
        }
        private void DrawBezierPath(Graphics g, Pen pen, int x1, int y1, int x2, int y2, int pathIndex)
        {
            //The point where we will add the curve
            int midX = (x1 + x2) / 2;
            int midY = (y1 + y2) / 2;

            int dx = x2 - x1;
            int dy = y2 - y1;
            double length = Math.Sqrt(dx * dx + dy * dy);

            if (length < 1) length = 1;
            // get an angle 90 degrees to the original line , gives direction to push
            double perpX = -dy / length;
            double perpY = dx / length;
            // 0 -> straight , odd -> +40 , even -> -40 
            int offset = pathIndex == 0 ? 0 : (pathIndex % 2 == 1 ? 40 : -40) * ((pathIndex + 1) / 2);
            // Tells : start , curve , end
            int ctrlX = (int)(midX + perpX * offset);
            int ctrlY = (int)(midY + perpY * offset);

            g.DrawBezier(pen, x1, y1, ctrlX, ctrlY, ctrlX, ctrlY, x2, y2);
        }
        /// Draw all existing routes as faint gray lines
        private void DrawBaseRoutes(Graphics g, GenericHashTable<string, AirportData> airports)
        {
            using (Pen grayPen = new Pen(Color.FromArgb(80, 128, 128, 128), 1))
            {
                string[] airportCodes = airports.GetAllKeys();
                foreach (var airportCode in airportCodes)
                {
                    var neighbors = graphService.GetNeighbors(airportCode);
                    var sourceData = airports.Get(airportCode);

                    foreach (var neighborCode in neighbors)
                    {
                        if (airports.ContainsKey(neighborCode))
                        {
                            var destData = airports.Get(neighborCode);
                            g.DrawLine(grayPen, sourceData.X, sourceData.Y, destData.X, destData.Y);
                        }
                    }
                }
            }
        }
        //  Draw found paths with Bezier curves and distinct neon colors + Shortest path is drawn in GREEN and drawn last (on top)
        private void DrawFoundPaths(Graphics g)
        {
            if (foundPaths == null || foundPaths.Length == 0) return;

            var airports = graphService.GetAllAirportData();

            // Sort paths so shortest path is drawn last (on top)
            PathResult[] sortedPaths = new PathResult[foundPaths.Length];
            int regularIndex = 0;
            PathResult? shortestPath = null;

            foreach (var path in foundPaths)
            {
                if (path.IsShortestPath)
                {
                    shortestPath = path;
                }
                else
                {
                    sortedPaths[regularIndex++] = path;
                }
            }

            // Add shortest path at the end
            if (shortestPath != null)
            {
                sortedPaths[foundPaths.Length - 1] = shortestPath;
            }

            // Draw each path
            int colorIndex = 1; // Start from index 1 (skip green for non-shortest paths)
            for (int pathIndex = 0; pathIndex < sortedPaths.Length; pathIndex++)
            {
                var pathResult = sortedPaths[pathIndex];
                if (pathResult == null || pathResult.Path.Length < 2) continue;

                // Get color for this path
                Color pathColor;
                int penWidth;
                if (pathResult.IsShortestPath)
                {
                    pathColor = Color.FromArgb(57, 255, 20); // Neon Green for shortest
                    penWidth = 4; // Thicker line
                }
                else
                {
                    pathColor = neonColors[colorIndex % neonColors.Length];
                    penWidth = 3;
                    colorIndex++;
                }

                using (Pen pathPen = new Pen(pathColor, penWidth))
                {
                    pathPen.EndCap = LineCap.ArrowAnchor;

                    // Draw each segment of the path
                    for (int i = 0; i < pathResult.Path.Length - 1; i++)
                    {
                        string fromCode = pathResult.Path[i];
                        string toCode = pathResult.Path[i + 1];

                        if (!airports.ContainsKey(fromCode) || !airports.ContainsKey(toCode))
                            continue;

                        var from = airports[fromCode];
                        var to = airports[toCode];

                        // Draw Bezier curve with dynamic offset based on path index
                        DrawBezierPath(g, pathPen, from.X, from.Y, to.X, to.Y, pathIndex);

                        // Draw distance label on edge
                        int distance = graphService.GetEdgeDistance(fromCode, toCode);
                        DrawDistanceLabel(g, from.X, from.Y, to.X, to.Y, distance, pathColor);
                    }
                }

                // Draw path label
                if (pathResult.Path.Length > 0 && airports.ContainsKey(pathResult.Path[0]))
                {
                    var startNode = airports[pathResult.Path[0]];
                    string pathLabel;
                    if (pathResult.IsShortestPath)
                    {
                        pathLabel = $"★ SHORTEST: {pathResult.TotalDistance} km, {pathResult.StopCount} stops";
                    }
                    else
                    {
                        pathLabel = $"Path {pathIndex + 1}: {pathResult.TotalDistance} km, {pathResult.StopCount} stops";
                    }

                    using (Font labelFont = new Font("Segoe UI", pathResult.IsShortestPath ? 9 : 8,
                           pathResult.IsShortestPath ? FontStyle.Bold : FontStyle.Bold))
                    using (Brush labelBrush = new SolidBrush(pathColor))
                    {
                        g.DrawString(pathLabel, labelFont, labelBrush, startNode.X + 25, startNode.Y - 30 - pathIndex * 15);
                    }
                }
            }
        }
        /// Draw distance label on edge
        private void DrawDistanceLabel(Graphics g, int x1, int y1, int x2, int y2, int distance, Color color)
        {
            if (distance == 0) return;

            // Calculate midpoint
            int midX = (x1 + x2) / 2;
            int midY = (y1 + y2) / 2;

            string distanceText = $"{distance} km";

            using (Font font = new Font("Segoe UI", 7, FontStyle.Bold))
            {
                SizeF textSize = g.MeasureString(distanceText, font);

                // Draw semi-transparent background
                using (Brush bgBrush = new SolidBrush(Color.FromArgb(180, 0, 0, 0)))
                {
                    g.FillRectangle(bgBrush, midX - textSize.Width / 2 - 2, midY - textSize.Height / 2 - 1,
                        textSize.Width + 4, textSize.Height + 2);
                }

                // Draw text
                using (Brush textBrush = new SolidBrush(color))
                {
                    g.DrawString(distanceText, font, textBrush,
                        midX - textSize.Width / 2, midY - textSize.Height / 2);
                }
            }
        }
        /// Draw all airport nodes as circles
        private void DrawAirportNodes(Graphics g, GenericHashTable<string, AirportData> airports)
        {
            int nodeRadius = 15;

            AirportData[] airportArray = airports.GetAllValues();
            foreach (var data in airportArray)
            {
                bool isInPath = false;
                bool isOriginOrDest = false;

                if (foundPaths != null && foundPaths.Length > 0)
                {
                    foreach (var pathResult in foundPaths)
                    {
                        for (int i = 0; i < pathResult.Path.Length; i++)
                        {
                            if (pathResult.Path[i] == data.Code)
                            {
                                isInPath = true;
                                if (i == 0 || i == pathResult.Path.Length - 1)
                                {
                                    isOriginOrDest = true;
                                }
                                break;
                            }
                        }
                        if (isInPath) break;
                    }
                }

                Color nodeColor = Color.FromArgb(60, 60, 60);
                Color borderColor = Color.FromArgb(100, 100, 100);
                int borderWidth = 2;

                if (isOriginOrDest)
                {
                    nodeColor = Color.FromArgb(57, 255, 20);
                    borderColor = Color.FromArgb(57, 255, 20);
                    borderWidth = 3;
                    nodeRadius = 18;
                }
                else if (isInPath)
                {
                    nodeColor = Color.FromArgb(80, 80, 80);
                    borderColor = Color.FromArgb(150, 150, 150);
                }

                using (Brush nodeBrush = new SolidBrush(nodeColor))
                using (Pen borderPen = new Pen(borderColor, borderWidth))
                {
                    g.FillEllipse(nodeBrush, data.X - nodeRadius, data.Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
                    g.DrawEllipse(borderPen, data.X - nodeRadius, data.Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
                }

                using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(isInPath ? Color.White : Color.Gray))
                {
                    SizeF textSize = g.MeasureString(data.Code, font);
                    g.DrawString(data.Code, font, textBrush,
                        data.X - textSize.Width / 2,
                        data.Y - textSize.Height / 2);
                }
            }
        }

        private void lblPathCount_Click(object sender, EventArgs e)
        {
        }

        private void cmbDest_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lblDest_Click(object sender, EventArgs e)
        {
        }
    }
}
