namespace HerdSync
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSignIn;
        private Button btnSignUp;
        private Panel panel1;
        private Button btnContactUs;
        private Button btnFeatures;
        private Button btnExit;
        private Label label1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            btnSignIn = new Button();
            btnSignUp = new Button();
            btnContactUs = new Button();
            btnFeatures = new Button();
            btnExit = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnSignIn);
            panel1.Controls.Add(btnSignUp);
            panel1.Controls.Add(btnContactUs);
            panel1.Controls.Add(btnFeatures);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 516);
            panel1.TabIndex = 0;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(216, 231);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(88, 47);
            btnSignIn.TabIndex = 0;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(361, 231);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(88, 47);
            btnSignUp.TabIndex = 1;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnContactUs
            // 
            btnContactUs.Location = new Point(556, 439);
            btnContactUs.Name = "btnContactUs";
            btnContactUs.Size = new Size(88, 47);
            btnContactUs.TabIndex = 2;
            btnContactUs.Text = "Contact Us";
            btnContactUs.UseVisualStyleBackColor = true;
            btnContactUs.Click += btnContactUs_Click;
            // 
            // btnFeatures
            // 
            btnFeatures.Location = new Point(574, 3);
            btnFeatures.Name = "btnFeatures";
            btnFeatures.Size = new Size(88, 47);
            btnFeatures.TabIndex = 3;
            btnFeatures.Text = "Features";
            btnFeatures.UseVisualStyleBackColor = true;
            btnFeatures.Click += btnFeatures_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(13, 439);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(88, 47);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(12, 3);
            label1.Name = "label1";
            label1.Size = new Size(89, 21);
            label1.TabIndex = 5;
            label1.Text = "HerdSync™";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 517);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "HerdSync";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
    }
}
