namespace HerdSync
{
    partial class AnimalRecordForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimalRecordForm));
            cmbSearchType = new ComboBox();
            txtAnimalSearch = new ComboBox();
            btnSearch = new Button();
            btnUploadPhoto = new Button();
            btnRemovePhoto = new Button();
            pbAnimalPhoto = new PictureBox();
            lblSpecies = new Label();
            lblSpeciesValue = new Label();
            lblGender = new Label();
            lblGenderValue = new Label();
            lblAge = new Label();
            lblAgeValue = new Label();
            lblOrigin = new Label();
            lblOriginValue = new Label();
            lblPurchaseDate = new Label();
            lblPurchaseDateValue = new Label();
            lblInitialWeight = new Label();
            lblInitialWeightValue = new Label();
            lblCurrentWeight = new Label();
            lblCurrentWeightValue = new Label();
            lblWeightGoal = new Label();
            lblWeightGoalValue = new Label();
            lblRFID = new Label();
            lblRFIDValue = new Label();
            lblTagID = new Label();
            lblTagIDValue = new Label();
            btnHome = new Button();
            ((System.ComponentModel.ISupportInitialize)pbAnimalPhoto).BeginInit();
            SuspendLayout();
            // 
            // cmbSearchType
            // 
            cmbSearchType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSearchType.FormattingEnabled = true;
            cmbSearchType.Items.AddRange(new object[] { "RFID", "Name" });
            cmbSearchType.Location = new Point(12, 12);
            cmbSearchType.Name = "cmbSearchType";
            cmbSearchType.Size = new Size(121, 23);
            cmbSearchType.TabIndex = 0;
            // 
            // txtAnimalSearch
            // 
            txtAnimalSearch.FormattingEnabled = true;
            txtAnimalSearch.Location = new Point(139, 12);
            txtAnimalSearch.Name = "txtAnimalSearch";
            txtAnimalSearch.Size = new Size(200, 23);
            txtAnimalSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(345, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.Location = new Point(450, 260);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(90, 23);
            btnUploadPhoto.TabIndex = 25;
            btnUploadPhoto.Text = "Upload Photo";
            btnUploadPhoto.UseVisualStyleBackColor = true;
            btnUploadPhoto.Click += btnUploadPhoto_Click;
            // 
            // btnRemovePhoto
            // 
            btnRemovePhoto.Location = new Point(560, 260);
            btnRemovePhoto.Name = "btnRemovePhoto";
            btnRemovePhoto.Size = new Size(90, 23);
            btnRemovePhoto.TabIndex = 26;
            btnRemovePhoto.Text = "Remove Photo";
            btnRemovePhoto.UseVisualStyleBackColor = true;
            btnRemovePhoto.Click += btnRemovePhoto_Click;
            // 
            // pbAnimalPhoto
            // 
            pbAnimalPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbAnimalPhoto.Location = new Point(450, 50);
            pbAnimalPhoto.Name = "pbAnimalPhoto";
            pbAnimalPhoto.Size = new Size(200, 200);
            pbAnimalPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbAnimalPhoto.TabIndex = 24;
            pbAnimalPhoto.TabStop = false;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(12, 50);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(49, 15);
            lblSpecies.TabIndex = 3;
            lblSpecies.Text = "Species:";
            // 
            // lblSpeciesValue
            // 
            lblSpeciesValue.AutoSize = true;
            lblSpeciesValue.Location = new Point(100, 50);
            lblSpeciesValue.Name = "lblSpeciesValue";
            lblSpeciesValue.Size = new Size(0, 15);
            lblSpeciesValue.TabIndex = 4;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(12, 110);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(48, 15);
            lblGender.TabIndex = 7;
            lblGender.Text = "Gender:";
            // 
            // lblGenderValue
            // 
            lblGenderValue.AutoSize = true;
            lblGenderValue.Location = new Point(100, 110);
            lblGenderValue.Name = "lblGenderValue";
            lblGenderValue.Size = new Size(0, 15);
            lblGenderValue.TabIndex = 8;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(12, 140);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(31, 15);
            lblAge.TabIndex = 9;
            lblAge.Text = "Age:";
            // 
            // lblAgeValue
            // 
            lblAgeValue.AutoSize = true;
            lblAgeValue.Location = new Point(100, 140);
            lblAgeValue.Name = "lblAgeValue";
            lblAgeValue.Size = new Size(0, 15);
            lblAgeValue.TabIndex = 10;
            // 
            // lblOrigin
            // 
            lblOrigin.AutoSize = true;
            lblOrigin.Location = new Point(12, 170);
            lblOrigin.Name = "lblOrigin";
            lblOrigin.Size = new Size(43, 15);
            lblOrigin.TabIndex = 11;
            lblOrigin.Text = "Origin:";
            // 
            // lblOriginValue
            // 
            lblOriginValue.AutoSize = true;
            lblOriginValue.Location = new Point(100, 170);
            lblOriginValue.Name = "lblOriginValue";
            lblOriginValue.Size = new Size(0, 15);
            lblOriginValue.TabIndex = 12;
            // 
            // lblPurchaseDate
            // 
            lblPurchaseDate.AutoSize = true;
            lblPurchaseDate.Location = new Point(12, 200);
            lblPurchaseDate.Name = "lblPurchaseDate";
            lblPurchaseDate.Size = new Size(85, 15);
            lblPurchaseDate.TabIndex = 13;
            lblPurchaseDate.Text = "Purchase Date:";
            // 
            // lblPurchaseDateValue
            // 
            lblPurchaseDateValue.AutoSize = true;
            lblPurchaseDateValue.Location = new Point(100, 200);
            lblPurchaseDateValue.Name = "lblPurchaseDateValue";
            lblPurchaseDateValue.Size = new Size(0, 15);
            lblPurchaseDateValue.TabIndex = 14;
            // 
            // lblInitialWeight
            // 
            lblInitialWeight.AutoSize = true;
            lblInitialWeight.Location = new Point(12, 230);
            lblInitialWeight.Name = "lblInitialWeight";
            lblInitialWeight.Size = new Size(80, 15);
            lblInitialWeight.TabIndex = 11;
            lblInitialWeight.Text = "Initial Weight:";
            // 
            // lblInitialWeightValue
            // 
            lblInitialWeightValue.AutoSize = true;
            lblInitialWeightValue.Location = new Point(100, 230);
            lblInitialWeightValue.Name = "lblInitialWeightValue";
            lblInitialWeightValue.Size = new Size(0, 15);
            lblInitialWeightValue.TabIndex = 12;
            // 
            // lblCurrentWeight
            // 
            lblCurrentWeight.AutoSize = true;
            lblCurrentWeight.Location = new Point(12, 260);
            lblCurrentWeight.Name = "lblCurrentWeight";
            lblCurrentWeight.Size = new Size(91, 15);
            lblCurrentWeight.TabIndex = 13;
            lblCurrentWeight.Text = "Current Weight:";
            // 
            // lblCurrentWeightValue
            // 
            lblCurrentWeightValue.AutoSize = true;
            lblCurrentWeightValue.Location = new Point(100, 260);
            lblCurrentWeightValue.Name = "lblCurrentWeightValue";
            lblCurrentWeightValue.Size = new Size(0, 15);
            lblCurrentWeightValue.TabIndex = 14;
            // 
            // lblWeightGoal
            // 
            lblWeightGoal.AutoSize = true;
            lblWeightGoal.Location = new Point(12, 290);
            lblWeightGoal.Name = "lblWeightGoal";
            lblWeightGoal.Size = new Size(75, 15);
            lblWeightGoal.TabIndex = 17;
            lblWeightGoal.Text = "Weight Goal:";
            // 
            // lblWeightGoalValue
            // 
            lblWeightGoalValue.AutoSize = true;
            lblWeightGoalValue.Location = new Point(100, 290);
            lblWeightGoalValue.Name = "lblWeightGoalValue";
            lblWeightGoalValue.Size = new Size(0, 15);
            lblWeightGoalValue.TabIndex = 18;
            // 
            // lblRFID
            // 
            lblRFID.AutoSize = true;
            lblRFID.Location = new Point(12, 320);
            lblRFID.Name = "lblRFID";
            lblRFID.Size = new Size(34, 15);
            lblRFID.TabIndex = 19;
            lblRFID.Text = "RFID:";
            // 
            // lblRFIDValue
            // 
            lblRFIDValue.AutoSize = true;
            lblRFIDValue.Location = new Point(100, 320);
            lblRFIDValue.Name = "lblRFIDValue";
            lblRFIDValue.Size = new Size(0, 15);
            lblRFIDValue.TabIndex = 20;
            // 
            // lblTagID
            // 
            lblTagID.AutoSize = true;
            lblTagID.Location = new Point(12, 350);
            lblTagID.Name = "lblTagID";
            lblTagID.Size = new Size(45, 15);
            lblTagID.TabIndex = 21;
            lblTagID.Text = "TAG ID:";
            // 
            // lblTagIDValue
            // 
            lblTagIDValue.AutoSize = true;
            lblTagIDValue.Location = new Point(100, 350);
            lblTagIDValue.Name = "lblTagIDValue";
            lblTagIDValue.Size = new Size(0, 15);
            lblTagIDValue.TabIndex = 22;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(713, 415);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(75, 23);
            btnHome.TabIndex = 23;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // AnimalRecordForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemovePhoto);
            Controls.Add(btnUploadPhoto);
            Controls.Add(pbAnimalPhoto);
            Controls.Add(btnHome);
            Controls.Add(lblTagIDValue);
            Controls.Add(lblTagID);
            Controls.Add(lblRFIDValue);
            Controls.Add(lblRFID);
            Controls.Add(lblWeightGoalValue);
            Controls.Add(lblWeightGoal);
            Controls.Add(lblCurrentWeightValue);
            Controls.Add(lblCurrentWeight);
            Controls.Add(lblInitialWeightValue);
            Controls.Add(lblInitialWeight);
            Controls.Add(lblPurchaseDateValue);
            Controls.Add(lblPurchaseDate);
            Controls.Add(lblOriginValue);
            Controls.Add(lblOrigin);
            Controls.Add(lblAgeValue);
            Controls.Add(lblAge);
            Controls.Add(lblGenderValue);
            Controls.Add(lblGender);
            Controls.Add(lblSpeciesValue);
            Controls.Add(lblSpecies);
            Controls.Add(btnSearch);
            Controls.Add(txtAnimalSearch);
            Controls.Add(cmbSearchType);
            Name = "AnimalRecordForm";
            Text = "Animal Record";
            ((System.ComponentModel.ISupportInitialize)pbAnimalPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbSearchType;
        private ComboBox txtAnimalSearch;
        private Button btnSearch;
        private PictureBox pbAnimalPhoto;
        private Button btnUploadPhoto;
        private Button btnRemovePhoto;
        private Label lblSpecies;
        private Label lblSpeciesValue;
        private Label lblGender;
        private Label lblGenderValue;
        private Label lblAge;
        private Label lblAgeValue;
        private Label lblOrigin;
        private Label lblOriginValue;
        private Label lblPurchaseDate;
        private Label lblPurchaseDateValue;
        private Label lblInitialWeight;
        private Label lblInitialWeightValue;
        private Label lblCurrentWeight;
        private Label lblCurrentWeightValue;
        private Label lblWeightGoal;
        private Label lblWeightGoalValue;
        private Label lblRFID;
        private Label lblRFIDValue;
        private Label lblTagID;
        private Label lblTagIDValue;
        private Button btnHome;
    }
}
