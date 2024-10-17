namespace HerdSync
{
    partial class LivestockMonitor
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCurrentTime;
        private DataGridView dgvRecords;
        private DataGridView dgvAnimalStatus;
        private Button btnHome;
        private Button btnClearRecords;
        private Label lblAnimalsOutside;

        // New UI components for setting parameters
        private DateTimePicker dtpEntryStartTime;
        private DateTimePicker dtpEntryEndTime;
        private Button btnSetEntryParameters;
        private DateTimePicker dtpExitStartTime;
        private DateTimePicker dtpExitEndTime;
        private Button btnSetExitParameters;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LivestockMonitor));
            lblCurrentTime = new Label();
            dgvRecords = new DataGridView();
            dgvAnimalStatus = new DataGridView();
            btnHome = new Button();
            btnClearRecords = new Button();
            lblAnimalsOutside = new Label();
            dtpEntryStartTime = new DateTimePicker();
            dtpEntryEndTime = new DateTimePicker();
            btnSetEntryParameters = new Button();
            dtpExitStartTime = new DateTimePicker();
            dtpExitEndTime = new DateTimePicker();
            btnSetExitParameters = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalStatus).BeginInit();
            SuspendLayout();
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(12, 9);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(82, 15);
            lblCurrentTime.TabIndex = 0;
            lblCurrentTime.Text = "Current Time: ";
            // 
            // dgvRecords
            // 
            dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecords.Location = new Point(15, 35);
            dgvRecords.Name = "dgvRecords";
            dgvRecords.Size = new Size(600, 400);
            dgvRecords.TabIndex = 1;
            // 
            // dgvAnimalStatus
            // 
            dgvAnimalStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalStatus.Location = new Point(640, 35);
            dgvAnimalStatus.Name = "dgvAnimalStatus";
            dgvAnimalStatus.Size = new Size(300, 400);
            dgvAnimalStatus.TabIndex = 2;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(865, 9);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(75, 23);
            btnHome.TabIndex = 3;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnClearRecords
            // 
            btnClearRecords.Location = new Point(765, 9);
            btnClearRecords.Name = "btnClearRecords";
            btnClearRecords.Size = new Size(94, 23);
            btnClearRecords.TabIndex = 4;
            btnClearRecords.Text = "Clear Records";
            btnClearRecords.UseVisualStyleBackColor = true;
            btnClearRecords.Click += btnClearRecords_Click;
            // 
            // lblAnimalsOutside
            // 
            lblAnimalsOutside.Location = new Point(0, 0);
            lblAnimalsOutside.Name = "lblAnimalsOutside";
            lblAnimalsOutside.Size = new Size(100, 23);
            lblAnimalsOutside.TabIndex = 0;
            // 
            // dtpEntryStartTime
            // 
            dtpEntryStartTime.Format = DateTimePickerFormat.Time;
            dtpEntryStartTime.Location = new Point(15, 450);
            dtpEntryStartTime.Name = "dtpEntryStartTime";
            dtpEntryStartTime.ShowUpDown = true;
            dtpEntryStartTime.Size = new Size(100, 23);
            dtpEntryStartTime.TabIndex = 5;
            // 
            // dtpEntryEndTime
            // 
            dtpEntryEndTime.Format = DateTimePickerFormat.Time;
            dtpEntryEndTime.Location = new Point(125, 450);
            dtpEntryEndTime.Name = "dtpEntryEndTime";
            dtpEntryEndTime.ShowUpDown = true;
            dtpEntryEndTime.Size = new Size(100, 23);
            dtpEntryEndTime.TabIndex = 6;
            // 
            // btnSetEntryParameters
            // 
            btnSetEntryParameters.Location = new Point(235, 450);
            btnSetEntryParameters.Name = "btnSetEntryParameters";
            btnSetEntryParameters.Size = new Size(100, 23);
            btnSetEntryParameters.TabIndex = 7;
            btnSetEntryParameters.Text = "Set Entry Time";
            btnSetEntryParameters.UseVisualStyleBackColor = true;
            btnSetEntryParameters.Click += btnSetEntryParameters_Click;
            // 
            // dtpExitStartTime
            // 
            dtpExitStartTime.Format = DateTimePickerFormat.Time;
            dtpExitStartTime.Location = new Point(345, 450);
            dtpExitStartTime.Name = "dtpExitStartTime";
            dtpExitStartTime.ShowUpDown = true;
            dtpExitStartTime.Size = new Size(100, 23);
            dtpExitStartTime.TabIndex = 8;
            // 
            // dtpExitEndTime
            // 
            dtpExitEndTime.Format = DateTimePickerFormat.Time;
            dtpExitEndTime.Location = new Point(455, 450);
            dtpExitEndTime.Name = "dtpExitEndTime";
            dtpExitEndTime.ShowUpDown = true;
            dtpExitEndTime.Size = new Size(100, 23);
            dtpExitEndTime.TabIndex = 9;
            // 
            // btnSetExitParameters
            // 
            btnSetExitParameters.Location = new Point(565, 450);
            btnSetExitParameters.Name = "btnSetExitParameters";
            btnSetExitParameters.Size = new Size(100, 23);
            btnSetExitParameters.TabIndex = 10;
            btnSetExitParameters.Text = "Set Exit Time";
            btnSetExitParameters.UseVisualStyleBackColor = true;
            btnSetExitParameters.Click += btnSetExitParameters_Click;
            // 
            // LivestockMonitor
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(958, 500);
            Controls.Add(btnSetExitParameters);
            Controls.Add(dtpExitEndTime);
            Controls.Add(dtpExitStartTime);
            Controls.Add(btnSetEntryParameters);
            Controls.Add(dtpEntryEndTime);
            Controls.Add(dtpEntryStartTime);
            Controls.Add(btnClearRecords);
            Controls.Add(btnHome);
            Controls.Add(dgvAnimalStatus);
            Controls.Add(dgvRecords);
            Controls.Add(lblCurrentTime);
            Name = "LivestockMonitor";
            Text = "Livestock Monitor";
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
