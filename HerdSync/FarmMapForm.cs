using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing;
using HerdSync;

namespace FarmMap
{
    public partial class FarmMapForm : Form
    {
        private GMapOverlay markersOverlay;
        private GMapOverlay polygonsOverlay;
        private List<PointLatLng> polygonPoints;
        private MainForm mainForm;
        private string additionalParameter;
        private DatabaseHelper databaseHelper;
        private bool isDraggingMode = false;

        public FarmMapForm(MainForm mainForm, string additionalParameter)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.additionalParameter = additionalParameter;
            databaseHelper = new DatabaseHelper();
            InitializeMap();
        }

        private async void FarmMapForm_Load(object sender, EventArgs e)
        {
            LoadSavedAreas();

            if (databaseHelper.GetSavedAreaNames().Count == 0)
            {
                string address = PromptForAddress();
                if (!string.IsNullOrEmpty(address))
                {
                    var point = await GeocodeAddress(address);
                    if (point != null)
                    {
                        gmap.Position = point.Value;
                        gmap.Zoom = 12;
                        var marker = new GMarkerGoogle(point.Value, GMarkerGoogleType.red_dot);
                        markersOverlay.Markers.Add(marker);
                    }
                    else
                    {
                        MessageBox.Show("Unable to find the location. Please try again.");
                    }
                }
            }
        }

        private void InitializeMap()
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyAWZH8KsO_9eQ6EW5eiak1TlzkBi1-gaOU"; // Updated with your API key
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.MinZoom = 2;
            gmap.MaxZoom = 18;
            gmap.Zoom = 10;
            gmap.DragButton = MouseButtons.Left;

            // Initialize overlays
            markersOverlay = new GMapOverlay("markers");
            polygonsOverlay = new GMapOverlay("polygons");
            gmap.Overlays.Add(markersOverlay);
            gmap.Overlays.Add(polygonsOverlay);
            polygonPoints = new List<PointLatLng>();

            // Event for selecting an area
            gmap.MouseClick += Gmap_MouseClick;
            gmap.OnMarkerClick += Gmap_OnMarkerClick;
        }


        private void Gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                markersOverlay.Markers.Remove(item);
                polygonPoints.Remove(item.Position);
                polygonsOverlay.Polygons.Clear();

                if (polygonPoints.Count > 2)
                {
                    GMapPolygon polygon = new GMapPolygon(polygonPoints, "Polygon");
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polygonsOverlay.Polygons.Add(polygon);
                }
                gmap.Refresh();
            }
        }

        private void Gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !isDraggingMode)
            {
                var point = gmap.FromLocalToLatLng(e.X, e.Y);
                polygonPoints.Add(point);

                var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                markersOverlay.Markers.Add(marker);

                if (polygonPoints.Count > 2)
                {
                    polygonsOverlay.Polygons.Clear();
                    GMapPolygon polygon = new GMapPolygon(polygonPoints, "Polygon");
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polygonsOverlay.Polygons.Add(polygon);
                }
            }
        }

        private void btnToggleMode_Click(object sender, EventArgs e)
        {
            isDraggingMode = !isDraggingMode;

            if (isDraggingMode)
            {
                gmap.CanDragMap = true;
                gmap.Cursor = Cursors.Hand;
            }
            else
            {
                gmap.CanDragMap = false;
                gmap.Cursor = Cursors.Cross;
            }
        }

        private string PromptForAddress()
        {
            using (InputDialog inputDialog = new InputDialog("Enter Address", "Please enter the address:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    return inputDialog.InputText;
                }
                else
                {
                    return null;
                }
            }
        }

        private async Task<PointLatLng?> GeocodeAddress(string address)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key=AIzaSyAWZH8KsO_9eQ6EW5eiak1TlzkBi1-gaOU";//API key here
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    JObject obj = JObject.Parse(json);

                    if (obj["status"].ToString() != "OK")
                    {
                        MessageBox.Show($"Geocoding error: {obj["status"]}\n{obj["error_message"]}");
                        return null;
                    }

                    if (obj["results"] != null && obj["results"].HasValues)
                    {
                        double lat = (double)obj["results"][0]["geometry"]["location"]["lat"];
                        double lon = (double)obj["results"][0]["geometry"]["location"]["lng"];
                        return new PointLatLng(lat, lon);
                    }
                    else
                    {
                        MessageBox.Show("No results found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception: {ex.Message}");
                }
            }
            return null;
        }

        private void btnSavePolygon_Click(object sender, EventArgs e)
        {
            using (InputDialog inputDialog = new InputDialog("Save Area", "Please enter a name for this area:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    var areaName = inputDialog.InputText;
                    var address = PromptForAddress(); // Get the address for the area
                    if (!string.IsNullOrEmpty(address))
                    {
                        databaseHelper.SaveArea(areaName, polygonPoints, address); // Pass the address to SaveArea
                        MessageBox.Show($"Polygon saved as '{areaName}' with address '{address}'.");
                        LoadSavedAreas();
                    }
                }
            }
        }

        private void btnViewArea_Click(object sender, EventArgs e)
        {
            using (InputDialog inputDialog = new InputDialog("View Area", "Please enter the name of the area to view:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    var areaName = inputDialog.InputText;
                    LoadPolygon(areaName);
                }
            }
        }

        private void LoadPolygon(string areaName)
        {
            var points = databaseHelper.LoadAreaPoints(areaName);
            if (points != null && points.Count > 0)
            {
                polygonPoints = points;
                polygonsOverlay.Polygons.Clear();
                GMapPolygon polygon = new GMapPolygon(polygonPoints, "Polygon");
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 1);
                polygonsOverlay.Polygons.Add(polygon);

                gmap.Position = points[0];
                gmap.Zoom = 12;
            }
            else
            {
                MessageBox.Show($"Area '{areaName}' not found or has no points.");
            }
        }

        private async void btnAddArea_Click(object sender, EventArgs e)
        {
            polygonPoints.Clear();
            markersOverlay.Markers.Clear();
            polygonsOverlay.Polygons.Clear();

            string address = PromptForAddress();
            if (!string.IsNullOrEmpty(address))
            {
                var point = await GeocodeAddress(address);
                if (point != null)
                {
                    gmap.Position = point.Value;
                    gmap.Zoom = 12;
                    var marker = new GMarkerGoogle(point.Value, GMarkerGoogleType.red_dot);
                    markersOverlay.Markers.Add(marker);
                }
                else
                {
                    MessageBox.Show("Unable to find the location. Please try again.");
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePage = new HomePageForm(mainForm, additionalParameter);
            homePage.Show();
        }

        private void LoadSavedAreas()
        {
            flowLayoutSavedAreas.Controls.Clear(); // Clear existing controls

            var savedAreas = databaseHelper.GetSavedAreaNamesWithAddresses();
            foreach (var area in savedAreas)
            {
                var areaPanel = new Panel()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = flowLayoutSavedAreas.Width - 20,
                    Height = 150, // Increased height to accommodate Remove button
                    Padding = new Padding(5)
                };

                var areaLabel = new Label()
                {
                    Text = area.Name,
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(5, 5)
                };

                var addressLabel = new Label()
                {
                    Text = area.Address,
                    AutoSize = true,
                    Font = new Font("Arial", 8, FontStyle.Italic),
                    Location = new Point(5, 25)
                };

                var purposeComboBox = new ComboBox()
                {
                    Width = 120,
                    Location = new Point(5, 50),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                purposeComboBox.Items.AddRange(new object[] { "Cropping", "Grazing", "Hay", "Resting" });
                purposeComboBox.SelectedIndex = 0; // Default selection

                var editButton = new Button()
                {
                    Text = "Edit",
                    Location = new Point(130, 50),
                    Width = 60
                };

                editButton.Click += (s, e) =>
                {
                    var selectedPurpose = purposeComboBox.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedPurpose))
                    {
                        databaseHelper.UpdateAreaType(area.Name, selectedPurpose);
                        MessageBox.Show($"Updated area '{area.Name}' with purpose '{selectedPurpose}'.");
                    }
                };

                // Add the Remove button
                var removeButton = new Button()
                {
                    Text = "Remove",
                    Location = new Point(5, 80), // Position it below the other controls
                    Width = 185 // Adjust width to align with the other buttons
                };

                removeButton.Click += (s, e) =>
                {
                    // Confirm before removing
                    var confirmResult = MessageBox.Show($"Are you sure you want to remove the area '{area.Name}'?",
                                                        "Confirm Remove",
                                                        MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        databaseHelper.RemoveArea(area.Name); // Remove from database
                        LoadSavedAreas(); // Refresh the saved areas list
                    }
                };

                areaPanel.Controls.Add(areaLabel);
                areaPanel.Controls.Add(addressLabel);
                areaPanel.Controls.Add(purposeComboBox);
                areaPanel.Controls.Add(editButton);
                areaPanel.Controls.Add(removeButton); // Add the Remove button to the panel

                flowLayoutSavedAreas.Controls.Add(areaPanel);
            }
        }

    }
}
