namespace FarmMap
{
    partial class FarmMapForm
    {
        private System.ComponentModel.IContainer components = null;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private Label lblStatus;
        private Button btnSavePolygon;
        private Button btnHome;
        private Button btnViewArea;
        private Button btnAddArea;
        private Button btnToggleMode;
        private FlowLayoutPanel flowLayoutSavedAreas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            gmap = new GMap.NET.WindowsForms.GMapControl();
            lblStatus = new Label();
            btnSavePolygon = new Button();
            btnHome = new Button();
            btnViewArea = new Button();
            btnAddArea = new Button();
            btnToggleMode = new Button();
            flowLayoutSavedAreas = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // gmap
            // 
            gmap.Bearing = 0F;
            gmap.CanDragMap = true;
            gmap.EmptyTileColor = Color.Navy;
            gmap.GrayScaleMode = false;
            gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gmap.LevelsKeepInMemmory = 5;
            gmap.Location = new Point(10, 11);
            gmap.MarkersEnabled = true;
            gmap.MaxZoom = 18;
            gmap.MinZoom = 2;
            gmap.MouseWheelZoomEnabled = true;
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gmap.Name = "gmap";
            gmap.NegativeMode = false;
            gmap.PolygonsEnabled = true;
            gmap.RetryLoadTile = 0;
            gmap.RoutesEnabled = true;
            gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gmap.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gmap.ShowTileGridLines = false;
            gmap.Size = new Size(504, 399);
            gmap.TabIndex = 0;
            gmap.Zoom = 10D;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 417);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Ready";
            // 
            // btnSavePolygon
            // 
            btnSavePolygon.Location = new Point(553, 416);
            btnSavePolygon.Name = "btnSavePolygon";
            btnSavePolygon.Size = new Size(66, 22);
            btnSavePolygon.TabIndex = 2;
            btnSavePolygon.Text = "Save";
            btnSavePolygon.UseVisualStyleBackColor = true;
            btnSavePolygon.Click += btnSavePolygon_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(624, 416);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(66, 22);
            btnHome.TabIndex = 3;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnViewArea
            // 
            btnViewArea.Location = new Point(482, 416);
            btnViewArea.Name = "btnViewArea";
            btnViewArea.Size = new Size(66, 22);
            btnViewArea.TabIndex = 4;
            btnViewArea.Text = "View Area";
            btnViewArea.UseVisualStyleBackColor = true;
            btnViewArea.Click += btnViewArea_Click;
            // 
            // btnAddArea
            // 
            btnAddArea.Location = new Point(411, 416);
            btnAddArea.Name = "btnAddArea";
            btnAddArea.Size = new Size(66, 22);
            btnAddArea.TabIndex = 5;
            btnAddArea.Text = "Add Area";
            btnAddArea.UseVisualStyleBackColor = true;
            btnAddArea.Click += btnAddArea_Click;
            // 
            // btnToggleMode
            // 
            btnToggleMode.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnToggleMode.Location = new Point(335, 416);
            btnToggleMode.Name = "btnToggleMode";
            btnToggleMode.Size = new Size(71, 22);
            btnToggleMode.TabIndex = 6;
            btnToggleMode.Text = "Toggle Mode";
            btnToggleMode.UseVisualStyleBackColor = true;
            btnToggleMode.Click += btnToggleMode_Click;
            // 
            // flowLayoutSavedAreas
            // 
            flowLayoutSavedAreas.AutoScroll = true; // Ensure auto-scroll is enabled
            flowLayoutSavedAreas.Location = new Point(520, 11);
            flowLayoutSavedAreas.Name = "flowLayoutSavedAreas";
            flowLayoutSavedAreas.Size = new Size(220, 405);
            flowLayoutSavedAreas.TabIndex = 7;
            // 
            // FarmMapForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 445);
            Controls.Add(flowLayoutSavedAreas);
            Controls.Add(btnToggleMode);
            Controls.Add(btnAddArea);
            Controls.Add(btnViewArea);
            Controls.Add(btnHome);
            Controls.Add(btnSavePolygon);
            Controls.Add(lblStatus);
            Controls.Add(gmap);
            Name = "FarmMapForm";
            Text = "Farm Map";
            Load += FarmMapForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
