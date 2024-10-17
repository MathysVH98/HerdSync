namespace HerdSync
{
    partial class HomePageForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnLogOut;
        private Panel panel1;
        private Label lblWeather;
        private Label label1;
        private Button btnAddAnimals;
        private Button btnAnimalRecords;
        private Button btnLivestockMonitor;
        private Button btnLivestockManager;
        private GroupBox gBoxAnimalsOutside;
        private GroupBox gBoxNewAnimals;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label lblCurrentUser;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageForm));
            btnLogOut = new Button();
            panel1 = new Panel();
            btnFarmMap = new Button();
            lblCurrentUser = new Label();
            groupBox5 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox3 = new GroupBox();
            gBoxNewAnimals = new GroupBox();
            gBoxAnimalsOutside = new GroupBox();
            lblAnimalsOutside = new Label();
            lblWeather = new Label();
            label1 = new Label();
            btnAddAnimals = new Button();
            btnAnimalRecords = new Button();
            btnLivestockMonitor = new Button();
            btnLivestockManager = new Button();
            panel1.SuspendLayout();
            gBoxAnimalsOutside.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.Transparent;
            btnLogOut.Location = new Point(1318, 648);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(75, 23);
            btnLogOut.TabIndex = 0;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnFarmMap);
            panel1.Controls.Add(lblCurrentUser);
            panel1.Controls.Add(groupBox5);
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(gBoxNewAnimals);
            panel1.Controls.Add(gBoxAnimalsOutside);
            panel1.Controls.Add(lblWeather);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnAddAnimals);
            panel1.Controls.Add(btnAnimalRecords);
            panel1.Controls.Add(btnLivestockMonitor);
            panel1.Controls.Add(btnLivestockManager);
            panel1.Controls.Add(btnLogOut);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1409, 758);
            panel1.TabIndex = 1;
            // 
            // btnFarmMap
            // 
            btnFarmMap.Location = new Point(3, 264);
            btnFarmMap.Name = "btnFarmMap";
            btnFarmMap.Size = new Size(190, 28);
            btnFarmMap.TabIndex = 0;
            btnFarmMap.Text = "Farm Map";
            btnFarmMap.UseVisualStyleBackColor = true;
            btnFarmMap.Click += btnFarmMap_Click;
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.BackColor = Color.Transparent;
            lblCurrentUser.Location = new Point(17, 64);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(73, 15);
            lblCurrentUser.TabIndex = 10;
            lblCurrentUser.Text = "Current User";
            // 
            // groupBox5
            // 
            groupBox5.Location = new Point(1163, 122);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(230, 100);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "groupBox5";
            // 
            // groupBox4
            // 
            groupBox4.Location = new Point(691, 122);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(230, 100);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "groupBox4";
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(927, 122);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(230, 100);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "groupBox3";
            // 
            // gBoxNewAnimals
            // 
            gBoxNewAnimals.Location = new Point(455, 122);
            gBoxNewAnimals.Name = "gBoxNewAnimals";
            gBoxNewAnimals.Size = new Size(230, 100);
            gBoxNewAnimals.TabIndex = 8;
            gBoxNewAnimals.TabStop = false;
            gBoxNewAnimals.Text = "New Animals";
            gBoxNewAnimals.Enter += gBoxNewAnimals_Enter;
            // 
            // gBoxAnimalsOutside
            // 
            gBoxAnimalsOutside.Controls.Add(lblAnimalsOutside);
            gBoxAnimalsOutside.Location = new Point(219, 122);
            gBoxAnimalsOutside.Name = "gBoxAnimalsOutside";
            gBoxAnimalsOutside.Size = new Size(230, 100);
            gBoxAnimalsOutside.TabIndex = 7;
            gBoxAnimalsOutside.TabStop = false;
            gBoxAnimalsOutside.Text = "Animals Outside";
            // 
            // lblAnimalsOutside
            // 
            lblAnimalsOutside.AutoSize = true;
            lblAnimalsOutside.Location = new Point(70, 44);
            lblAnimalsOutside.Name = "lblAnimalsOutside";
            lblAnimalsOutside.Size = new Size(94, 15);
            lblAnimalsOutside.TabIndex = 11;
            lblAnimalsOutside.Text = "Animals Outside";
            // 
            // lblWeather
            // 
            lblWeather.AutoSize = true;
            lblWeather.BackColor = Color.Transparent;
            lblWeather.Location = new Point(1174, 29);
            lblWeather.Name = "lblWeather";
            lblWeather.Size = new Size(109, 15);
            lblWeather.TabIndex = 1;
            lblWeather.Text = "Weather: Loading...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(249, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 21);
            label1.TabIndex = 5;
            label1.Text = "HerdSync™";
            // 
            // btnAddAnimals
            // 
            btnAddAnimals.Location = new Point(3, 230);
            btnAddAnimals.Name = "btnAddAnimals";
            btnAddAnimals.Size = new Size(190, 28);
            btnAddAnimals.TabIndex = 0;
            btnAddAnimals.Text = "Add Animals";
            btnAddAnimals.UseVisualStyleBackColor = true;
            btnAddAnimals.Click += btnAddAnimals_Click;
            // 
            // btnAnimalRecords
            // 
            btnAnimalRecords.Location = new Point(3, 194);
            btnAnimalRecords.Name = "btnAnimalRecords";
            btnAnimalRecords.Size = new Size(190, 30);
            btnAnimalRecords.TabIndex = 3;
            btnAnimalRecords.Text = "Animal Records";
            btnAnimalRecords.UseVisualStyleBackColor = true;
            btnAnimalRecords.Click += btnAnimalRecords_Click;
            // 
            // btnLivestockMonitor
            // 
            btnLivestockMonitor.Location = new Point(3, 158);
            btnLivestockMonitor.Name = "btnLivestockMonitor";
            btnLivestockMonitor.Size = new Size(190, 30);
            btnLivestockMonitor.TabIndex = 2;
            btnLivestockMonitor.Text = "Livestock Monitor";
            btnLivestockMonitor.UseVisualStyleBackColor = true;
            btnLivestockMonitor.Click += btnLivestockMonitor_Click;
            // 
            // btnLivestockManager
            // 
            btnLivestockManager.Location = new Point(3, 122);
            btnLivestockManager.Name = "btnLivestockManager";
            btnLivestockManager.Size = new Size(190, 30);
            btnLivestockManager.TabIndex = 1;
            btnLivestockManager.Text = "Livestock Manager";
            btnLivestockManager.UseVisualStyleBackColor = true;
            btnLivestockManager.Click += btnLivestockManager_Click;
            // 
            // HomePageForm
            // 
            ClientSize = new Size(1408, 755);
            Controls.Add(panel1);
            Name = "HomePageForm";
            Text = "Home Page";
            Load += HomePageForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gBoxAnimalsOutside.ResumeLayout(false);
            gBoxAnimalsOutside.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblAnimalsOutside;
        private Button btnFarmMap;
    }
}
