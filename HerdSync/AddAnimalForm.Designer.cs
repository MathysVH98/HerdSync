namespace HerdSync
{
    partial class AddAnimalForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panel1;
        private GroupBox gBoxAddAnimals;
        private Button btnHome;
        private Button btnSave;
        private ComboBox cmbBoxStatusOfAnimal;
        private DateTimePicker dateTimePicker2;
        private ComboBox cmbBoxStatusOArrival;
        private TextBox txtFather;
        private TextBox txtMother;
        private ComboBox cmbBoxSex;
        private DateTimePicker dateTimePicker1;
        private ComboBox cmbBoxOrigin;
        private ComboBox cmbBoxSpecies;
        private TextBox txtName;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblRfidValue;
        private TextBox txtInitialWeight;
        private TextBox txtCurrentWeight;
        private TextBox txtWeightGoal;
        private TextBox txtTagID;
        private Label lblInitialWeight;
        private Label lblCurrentWeight;
        private Label lblWeightGoal;
        private Label lblTagID;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAnimalForm));
            panel1 = new Panel();
            gBoxAddAnimals = new GroupBox();
            lblRfidValue = new Label();
            btnHome = new Button();
            btnSave = new Button();
            cmbBoxStatusOfAnimal = new ComboBox();
            dateTimePicker2 = new DateTimePicker();
            cmbBoxStatusOArrival = new ComboBox();
            txtFather = new TextBox();
            txtMother = new TextBox();
            cmbBoxSex = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            cmbBoxOrigin = new ComboBox();
            cmbBoxSpecies = new ComboBox();
            txtName = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblInitialWeight = new Label();
            lblCurrentWeight = new Label();
            lblWeightGoal = new Label();
            lblTagID = new Label();
            txtInitialWeight = new TextBox();
            txtCurrentWeight = new TextBox();
            txtWeightGoal = new TextBox();
            txtTagID = new TextBox();
            panel1.SuspendLayout();
            gBoxAddAnimals.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(gBoxAddAnimals);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1170, 346);
            panel1.TabIndex = 0;
            // 
            // gBoxAddAnimals
            // 
            gBoxAddAnimals.BackgroundImage = (Image)resources.GetObject("gBoxAddAnimals.BackgroundImage");
            gBoxAddAnimals.Controls.Add(lblRfidValue);
            gBoxAddAnimals.Controls.Add(btnHome);
            gBoxAddAnimals.Controls.Add(btnSave);
            gBoxAddAnimals.Controls.Add(cmbBoxStatusOfAnimal);
            gBoxAddAnimals.Controls.Add(dateTimePicker2);
            gBoxAddAnimals.Controls.Add(cmbBoxStatusOArrival);
            gBoxAddAnimals.Controls.Add(txtFather);
            gBoxAddAnimals.Controls.Add(txtMother);
            gBoxAddAnimals.Controls.Add(cmbBoxSex);
            gBoxAddAnimals.Controls.Add(dateTimePicker1);
            gBoxAddAnimals.Controls.Add(cmbBoxOrigin);
            gBoxAddAnimals.Controls.Add(cmbBoxSpecies);
            gBoxAddAnimals.Controls.Add(txtName);
            gBoxAddAnimals.Controls.Add(label11);
            gBoxAddAnimals.Controls.Add(label10);
            gBoxAddAnimals.Controls.Add(label9);
            gBoxAddAnimals.Controls.Add(label8);
            gBoxAddAnimals.Controls.Add(label7);
            gBoxAddAnimals.Controls.Add(label6);
            gBoxAddAnimals.Controls.Add(label5);
            gBoxAddAnimals.Controls.Add(label4);
            gBoxAddAnimals.Controls.Add(label3);
            gBoxAddAnimals.Controls.Add(label2);
            gBoxAddAnimals.Controls.Add(label1);
            gBoxAddAnimals.Controls.Add(lblInitialWeight);
            gBoxAddAnimals.Controls.Add(lblCurrentWeight);
            gBoxAddAnimals.Controls.Add(lblWeightGoal);
            gBoxAddAnimals.Controls.Add(lblTagID);
            gBoxAddAnimals.Controls.Add(txtInitialWeight);
            gBoxAddAnimals.Controls.Add(txtCurrentWeight);
            gBoxAddAnimals.Controls.Add(txtWeightGoal);
            gBoxAddAnimals.Controls.Add(txtTagID);
            gBoxAddAnimals.Location = new Point(3, 3);
            gBoxAddAnimals.Name = "gBoxAddAnimals";
            gBoxAddAnimals.Size = new Size(1164, 340);
            gBoxAddAnimals.TabIndex = 0;
            gBoxAddAnimals.TabStop = false;
            gBoxAddAnimals.Text = "Add Animal";
            // 
            // lblRfidValue
            // 
            lblRfidValue.AutoSize = true;
            lblRfidValue.Location = new Point(50, 72);
            lblRfidValue.Name = "lblRfidValue";
            lblRfidValue.Size = new Size(0, 15);
            lblRfidValue.TabIndex = 25;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(1082, 21);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(75, 23);
            btnHome.TabIndex = 24;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1082, 306);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 23;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbBoxStatusOfAnimal
            // 
            cmbBoxStatusOfAnimal.FormattingEnabled = true;
            cmbBoxStatusOfAnimal.Location = new Point(6, 267);
            cmbBoxStatusOfAnimal.Name = "cmbBoxStatusOfAnimal";
            cmbBoxStatusOfAnimal.Size = new Size(121, 23);
            cmbBoxStatusOfAnimal.TabIndex = 22;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(769, 171);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(203, 23);
            dateTimePicker2.TabIndex = 21;
            // 
            // cmbBoxStatusOArrival
            // 
            cmbBoxStatusOArrival.FormattingEnabled = true;
            cmbBoxStatusOArrival.Location = new Point(585, 171);
            cmbBoxStatusOArrival.Name = "cmbBoxStatusOArrival";
            cmbBoxStatusOArrival.Size = new Size(121, 23);
            cmbBoxStatusOArrival.TabIndex = 20;
            // 
            // txtFather
            // 
            txtFather.Location = new Point(374, 171);
            txtFather.Name = "txtFather";
            txtFather.Size = new Size(100, 23);
            txtFather.TabIndex = 19;
            // 
            // txtMother
            // 
            txtMother.Location = new Point(172, 171);
            txtMother.Name = "txtMother";
            txtMother.Size = new Size(100, 23);
            txtMother.TabIndex = 18;
            // 
            // cmbBoxSex
            // 
            cmbBoxSex.FormattingEnabled = true;
            cmbBoxSex.Location = new Point(6, 171);
            cmbBoxSex.Name = "cmbBoxSex";
            cmbBoxSex.Size = new Size(121, 23);
            cmbBoxSex.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(769, 72);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(203, 23);
            dateTimePicker1.TabIndex = 16;
            // 
            // cmbBoxOrigin
            // 
            cmbBoxOrigin.FormattingEnabled = true;
            cmbBoxOrigin.Location = new Point(585, 72);
            cmbBoxOrigin.Name = "cmbBoxOrigin";
            cmbBoxOrigin.Size = new Size(121, 23);
            cmbBoxOrigin.TabIndex = 15;
            // 
            // cmbBoxSpecies
            // 
            cmbBoxSpecies.FormattingEnabled = true;
            cmbBoxSpecies.Location = new Point(374, 72);
            cmbBoxSpecies.Name = "cmbBoxSpecies";
            cmbBoxSpecies.Size = new Size(121, 23);
            cmbBoxSpecies.TabIndex = 14;
            cmbBoxSpecies.DrawItem += cmbBoxSpecies_DrawItem;
            // 
            // txtName
            // 
            txtName.Location = new Point(172, 72);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(6, 249);
            label11.Name = "label11";
            label11.Size = new Size(92, 15);
            label11.TabIndex = 10;
            label11.Text = "Status of animal";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Location = new Point(769, 153);
            label10.Name = "label10";
            label10.Size = new Size(68, 15);
            label10.TabIndex = 9;
            label10.Text = "Arrival Date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(585, 153);
            label9.Name = "label9";
            label9.Size = new Size(105, 15);
            label9.TabIndex = 8;
            label9.Text = "Status upon arrival";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(374, 153);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 7;
            label8.Text = "Father";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(172, 153);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 6;
            label7.Text = "Mother";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(6, 153);
            label6.Name = "label6";
            label6.Size = new Size(25, 15);
            label6.TabIndex = 5;
            label6.Text = "Sex";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(769, 54);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 4;
            label5.Text = "Date of birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(585, 54);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "Origin";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(374, 54);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Species";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(172, 54);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(22, 54);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 0;
            label1.Text = "Rfid";
            // 
            // lblInitialWeight
            // 
            lblInitialWeight.AutoSize = true;
            lblInitialWeight.BackColor = Color.Transparent;
            lblInitialWeight.Location = new Point(172, 249);
            lblInitialWeight.Name = "lblInitialWeight";
            lblInitialWeight.Size = new Size(80, 15);
            lblInitialWeight.TabIndex = 26;
            lblInitialWeight.Text = "Initial Weight:";
            // 
            // lblCurrentWeight
            // 
            lblCurrentWeight.AutoSize = true;
            lblCurrentWeight.BackColor = Color.Transparent;
            lblCurrentWeight.Location = new Point(383, 249);
            lblCurrentWeight.Name = "lblCurrentWeight";
            lblCurrentWeight.Size = new Size(91, 15);
            lblCurrentWeight.TabIndex = 27;
            lblCurrentWeight.Text = "Current Weight:";
            // 
            // lblWeightGoal
            // 
            lblWeightGoal.AutoSize = true;
            lblWeightGoal.BackColor = Color.Transparent;
            lblWeightGoal.Location = new Point(585, 249);
            lblWeightGoal.Name = "lblWeightGoal";
            lblWeightGoal.Size = new Size(75, 15);
            lblWeightGoal.TabIndex = 28;
            lblWeightGoal.Text = "Weight Goal:";
            // 
            // lblTagID
            // 
            lblTagID.AutoSize = true;
            lblTagID.BackColor = Color.Transparent;
            lblTagID.Location = new Point(769, 249);
            lblTagID.Name = "lblTagID";
            lblTagID.Size = new Size(45, 15);
            lblTagID.TabIndex = 29;
            lblTagID.Text = "TAG ID:";
            // 
            // txtInitialWeight
            // 
            txtInitialWeight.Location = new Point(172, 267);
            txtInitialWeight.Name = "txtInitialWeight";
            txtInitialWeight.Size = new Size(100, 23);
            txtInitialWeight.TabIndex = 30;
            // 
            // txtCurrentWeight
            // 
            txtCurrentWeight.Location = new Point(383, 267);
            txtCurrentWeight.Name = "txtCurrentWeight";
            txtCurrentWeight.Size = new Size(100, 23);
            txtCurrentWeight.TabIndex = 31;
            // 
            // txtWeightGoal
            // 
            txtWeightGoal.Location = new Point(585, 267);
            txtWeightGoal.Name = "txtWeightGoal";
            txtWeightGoal.Size = new Size(100, 23);
            txtWeightGoal.TabIndex = 32;
            // 
            // txtTagID
            // 
            txtTagID.Location = new Point(769, 267);
            txtTagID.Name = "txtTagID";
            txtTagID.Size = new Size(100, 23);
            txtTagID.TabIndex = 33;
            // 
            // AddAnimalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 378);
            Controls.Add(panel1);
            Name = "AddAnimalForm";
            Text = "AddAnimalForm";
            panel1.ResumeLayout(false);
            gBoxAddAnimals.ResumeLayout(false);
            gBoxAddAnimals.PerformLayout();
            ResumeLayout(false);
        }
    }
}
